using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class CategoryManager : ManagerBase,ICategoryService
    {
       

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork, mapper)
        {
            
        }

        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = Mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            var addedCategory = await UnitOfWork.Categories.AddAsync(category);
            //.ContinueWith(t=>_unitOfWork.SaveAsync()) ;
            await UnitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Succes, Messages.Category.Add(addedCategory.Name),new
                CategoryDto
            {
                Category=addedCategory,
                ResultStatus=ResultStatus.Succes,
                Message= Messages.Category.Add(addedCategory.Name)
            }
                );
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var categoriesCount= await UnitOfWork.Categories.CountAsync();
            if (categoriesCount>-1)
            {
                return new DataResult<int>(ResultStatus.Succes, categoriesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata oluştu.",-1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var categoriesCount = await UnitOfWork.Categories.CountAsync(c=>!c.IsDeleted);
            if (categoriesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Succes, categoriesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata oluştu.", -1);
            }
        }

        public async Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName)
        {

            var category = await UnitOfWork.Categories.GetAsync(c => c.id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.IsActive = false;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                var deletedCategory = await UnitOfWork.Categories.UpdateAsync(category);
                await UnitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Succes, Messages.Category.Delete(deletedCategory.Name), new CategoryDto
                {
                    Category = deletedCategory,
                    ResultStatus = ResultStatus.Succes,
                    Message = Messages.Category.Delete(deletedCategory.Name)
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Category.NotFound(isPlural: false)
            });
        }
        

        public async Task<IDataResult<CategoryDto>> GetAsync(int categoryId)
        {
            var category= await UnitOfWork.Categories.GetAsync(c=>c.id==categoryId);
            if (category!=null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Succes, new CategoryDto
                {
                    Category= category,
                    ResultStatus=ResultStatus.Succes
                });

            }
            return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural:false), new
                CategoryDto
            {
                Category=null,
                ResultStatus=ResultStatus.Error,
                Message= Messages.Category.NotFound(isPlural: false)
            }
                );

        } 

        public async Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
           var categories= await UnitOfWork.Categories.GetAllAsync(null);
            if (categories.Count>-1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Succes,new CategoryListDto
                {
                    Categories= categories,
                    ResultStatus= ResultStatus.Succes
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: true), new CategoryListDto
            {
                Categories=null,
                ResultStatus= ResultStatus.Error,
                Message= Messages.Category.NotFound(isPlural: true)

            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => !c.IsDeleted);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Succes, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: true), new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Category.NotFound(isPlural: true)

            });
        
      
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => !c.IsDeleted&&c.IsActive);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Succes, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Succes

                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId)
        {
            var result = await UnitOfWork.Categories.AnyAsync(c => c.id==categoryId);
            if (result)
            {
                var category = await UnitOfWork.Categories.GetAsync(c=>c.id == categoryId);
                var categoryUpdateDto= Mapper.Map<CategoryUpdateDto>(category);
                return new DataResult<CategoryUpdateDto>(ResultStatus.Succes,categoryUpdateDto);
            }
            else
            {
                return new DataResult<CategoryUpdateDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), null);
            }
        }

        public async Task<IResult> HardDeleteAsync(int categoryId)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.id == categoryId);
            if (category != null)
            {

                await UnitOfWork.Categories.DeleteAsync(category).ContinueWith(t => UnitOfWork.SaveAsync());
                return new Result(ResultStatus.Succes, Messages.Category.HardDelete(category.Name));

            }
            return new Result(ResultStatus.Error, Messages.Category.NotFound(isPlural: true));
        }

        public async Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modidiedByName)
        {
                var oldCategory= await UnitOfWork.Categories.GetAsync(c=>c.id==categoryUpdateDto.Id);
                var category=Mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto,oldCategory);
                category.ModifiedByName = modidiedByName;
                var updatedCategory=  await UnitOfWork.Categories.UpdateAsync(category);
                //.ContinueWith(t=>_unitOfWork.SaveAsync());
                await UnitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Succes, Messages.Category.Update(updatedCategory.Name), new
                CategoryDto
            {
                Category = updatedCategory,
                ResultStatus = ResultStatus.Succes,
                Message = Messages.Category.Update(updatedCategory.Name)
            }) ;


        }

        public async Task<IDataResult<CategoryListDto>> GetAllByDeletedAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => !c.IsDeleted );
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Succes, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Succes

                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: true), null);
        }

        public async  Task<IDataResult<CategoryDto>> UndoDeleteAsync(int categoryId, string modifiedByName)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.id == categoryId);
            if (category != null)
            {
                category.IsDeleted = false;
                category.IsActive = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                var deletedCategory = await UnitOfWork.Categories.UpdateAsync(category);
                await UnitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Succes, Messages.Category.UndoDelete(deletedCategory.Name), new CategoryDto
                {
                    Category = deletedCategory,
                    ResultStatus = ResultStatus.Succes,
                    Message = Messages.Category.UndoDelete(deletedCategory.Name)
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Category.NotFound(isPlural: false)
            });
        }
    }

        
    
}
