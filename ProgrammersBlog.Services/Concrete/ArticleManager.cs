using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Mappings;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ProgrammersBlog.Services.Utilities.Messages;
using Article = ProgrammersBlog.Entities.Concrete.Article;

namespace ProgrammersBlog.Services.Concrete
{
    public class ArticleManager : ManagerBase, IArticleService
    {

        private readonly UserManager<User> _userManager;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
        }

        public async Task<IResult> AddAsync(ArticleAddDto articleAddDto, string createdByName,int userId)
        {
            //var article = Mapper.Map<Article>(articleAddDto);
            //article.CreatedByName = createdByName;
            //article.ModifiedByName = createdByName;
            //article.UserId = 1;
            //await UnitOfWork.Articles.AddAsync(article).ContinueWith(t => UnitOfWork.SaveAsync());
            //return new Result(ResultStatus.Succes, Messages.Article.Add(articleAddDto.Title));
            var article = Mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.Note = "Deneme";
            article.UserId = userId;
            await UnitOfWork.Articles.AddAsync(article);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Succes, Messages.Article.Add(article.Title));

        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var articlesCount = await UnitOfWork.Articles.CountAsync();
            if (articlesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Succes, articlesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata oluştu.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var articlesCount = await UnitOfWork.Articles.CountAsync(a=>!a.IsDeleted);
            if (articlesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Succes, articlesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata oluştu.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int articleId, string modifiedByName)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.id == articleId);
            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.id == articleId);
                article.IsDeleted = true;
                article.IsActive = false;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                await UnitOfWork.Articles.UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Succes, Messages.Article.Delete(article.Title));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(isPlural: false));
        }

        public async Task<IDataResult<ArticleDto>> GetAsync(int articleId)
        {
            var article = await UnitOfWork.Articles.GetAsync(a => a.id == articleId, a => a.User, a => a.Category);
            if (article!=null)
            {
                //var comment = await UnitOfWork.Comments.GetAllAsync(c => c.ArticleId == articleId && c.IsDeleted == false&&c.IsActive==true);
                article.Comments = await UnitOfWork.Comments.GetAllAsync(a=>!a.IsDeleted && a.IsActive && a.ArticleId==articleId, c => c.Article);


                return new DataResult<ArticleDto>(ResultStatus.Succes, new ArticleDto
                {
                    Article=article,
                    ResultStatus=ResultStatus.Succes

                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural:false), null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllAsync()
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);
            if (articles.Count>-1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles=articles,
                    ResultStatus=ResultStatus.Succes

                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategoryAsync(int categoryId)
        {
            var result = await UnitOfWork.Categories.AnyAsync(c => c.id == categoryId);
            if (result)
            {
                var articles=await UnitOfWork.Articles.GetAllAsync(a=>a.CategoryId==categoryId&&!a.IsDeleted, a => a.User,a => a.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Succes

                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: true), null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: false), null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAsync()
        {
            var articles= await UnitOfWork.Articles.GetAllAsync(a=>!a.IsDeleted,ar=>ar.User,articles=>articles.Category);
            //throw new SqlNullValueException();
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Succes

                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: true), null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, ar => ar.User, 
                ar => ar.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Succes

                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: true), null);
        }

        public async Task<IResult> HardDeleteAsync(int articleId)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.id == articleId);
            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.id == articleId);
                await UnitOfWork.Articles.DeleteAsync(article);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Succes, Messages.Article.HardDelete(article.Title));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(ArticleUpdateDto articleUpdateDto, string modidiedByName)
        {
            var oldArticle = await UnitOfWork.Articles.GetAsync(a => a.id == articleUpdateDto.Id);
            var article = Mapper.Map<ArticleUpdateDto, Article>(articleUpdateDto, oldArticle);
            article.ModifiedByName = modidiedByName;
            await UnitOfWork.Articles.UpdateAsync(article);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Succes, Messages.Article.Update(article.Title));

        }

        public async Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(int articleId)
        {
            var result = await UnitOfWork.Articles.AnyAsync(c => c.id == articleId);
            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(c => c.id == articleId);
                var articleUpdateDto = Mapper.Map<ArticleUpdateDto>(article);
                return new DataResult<ArticleUpdateDto>(ResultStatus.Succes, articleUpdateDto);
            }
            else
            {
                return new DataResult<ArticleUpdateDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: false), null);
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByDeletedAsync()
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, ar => ar.User,
              ar => ar.Category);
            
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Succes

                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: true), null);
        }

        public async Task<IResult> UndoDeleteAsync(int articleId, string modifiedByName)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.id == articleId);
            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.id == articleId);
                article.IsDeleted = false;
                article.IsActive = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                await UnitOfWork.Articles.UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Succes, Messages.Article.UndoDelete(article.Title));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(isPlural: false));
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByViewCountAsync(bool isAscending, int? takeSize)
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(a => a.IsActive && !a.IsDeleted, a => a.Category,
                a => a.User);
            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.ViewsCount)
                : articles.OrderByDescending(a => a.ViewsCount);
            return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
            {
                Articles=takeSize==null? sortedArticles.ToList():
                sortedArticles.Take(takeSize.Value).ToList(),
            });

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = categoryId == null
                ? await UnitOfWork.Articles.GetAllAsync(a => a.IsActive && !a.IsDeleted, a => a.Category, a => a.User)
                : await UnitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && a.IsActive && a.IsDeleted, a => a.Category, a => a.User);
            var sortedArticles = isAscending
                ? articles.OrderBy(a=>a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a=>a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
            {
                Articles=sortedArticles,
                CategoryId=categoryId==null ? null : categoryId.Value,
                CurrentPage=currentPage,
                PageSize=pageSize,
                TotalCount=articles.Count,
                IsAscending=isAscending
            });

        }

        public async Task<IDataResult<ArticleListDto>> SeachAsync(string keyword, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                var articles = await UnitOfWork.Articles.GetAllAsync(a => a.IsActive && !a.IsDeleted,
                    a => a.Category, a => a.User);
                var sortedArticles = isAscending
                    ? articles.OrderBy(a => a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                    : articles.OrderByDescending(a => a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = sortedArticles,
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalCount = articles.Count,
                    IsAscending = isAscending
                });
            }

            var searchedArticles = await UnitOfWork.Articles.SearchAsync(new List<Expression<Func<Article, bool>>>
            {
                (a)=>a.Title.Contains(keyword),
                (a)=>a.Category.Name.Contains(keyword),
                (a)=>a.SeoDescription.Contains(keyword),
                (a)=>a.SeoTags.Contains(keyword)
            },a=>a.Category,a=>a.User);

            var searchAndSortedArticles = isAscending
                ? searchedArticles.OrderBy(a => a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : searchedArticles.OrderByDescending(a => a.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
            {
                Articles = searchAndSortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = searchedArticles.Count,
                IsAscending = isAscending
            });
        }

        public async Task<IResult> IncreaseViewCountAsync(int articleId)
        {
            var article = await UnitOfWork.Articles.GetAsync(a => a.id == articleId);
            if (article==null)
            {
                return new Result(ResultStatus.Error, Messages.Article.NotFound(false));
            }
            article.ViewsCount += 1;
            await UnitOfWork.Articles.UpdateAsync(article);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Succes);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByUserIdOnFilter(int userId, FilterBy filterBy, OrderBy orderBy, bool isAscending, int takeSize, int categoryId, DateTime startAt, DateTime endAt, int minViewCount, int maxViewCount, int minCommentCount, int maxCommentCount)
        {
            var anyUser = await _userManager.Users.AnyAsync(u => u.Id == userId);
            if (!anyUser)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Error, $"{userId} numaralı kullanıcı bulunamadı.", null);
            }
            var userArticles =
                await UnitOfWork.Articles.GetAllAsync(a => a.IsActive && !a.IsDeleted && a.UserId == userId);
            List<Article> sortedArticles = new List<Article>();
            switch (filterBy)
            {
                case FilterBy.Category:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.CategoryId == categoryId).Take(takeSize)
                                .OrderBy(a => a.Date).ToList()
                                : userArticles.Where(a => a.CategoryId == categoryId).Take(takeSize)
                                .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                               ? userArticles.Where(a => a.CategoryId == categoryId).Take(takeSize)
                               .OrderBy(a => a.ViewsCount).ToList()
                               : userArticles.Where(a => a.CategoryId == categoryId).Take(takeSize)
                               .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                               ? userArticles.Where(a => a.CategoryId == categoryId).Take(takeSize)
                               .OrderBy(a => a.CommentCount).ToList()
                               : userArticles.Where(a => a.CategoryId == categoryId).Take(takeSize)
                               .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.Date:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                .OrderBy(a => a.Date).ToList()
                                : userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                                .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                               ? userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                               .OrderBy(a => a.ViewsCount).ToList()
                               : userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                               .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                               ? userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                               .OrderBy(a => a.CommentCount).ToList()
                               : userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takeSize)
                               .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.ViewCount:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.ViewsCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                                .OrderBy(a => a.Date).ToList()
                                : userArticles.Where(a => a.ViewsCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                                .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                               ? userArticles.Where(a => a.ViewsCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                               .OrderBy(a => a.ViewsCount).ToList()
                               : userArticles.Where(a => a.ViewsCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                               .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                               ? userArticles.Where(a => a.ViewsCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                               .OrderBy(a => a.CommentCount).ToList()
                               : userArticles.Where(a => a.ViewsCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                               .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.CommentCount:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.CommentCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                                .OrderBy(a => a.Date).ToList()
                                : userArticles.Where(a => a.CommentCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                                .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                               ? userArticles.Where(a => a.CommentCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                               .OrderBy(a => a.ViewsCount).ToList()
                               : userArticles.Where(a => a.CommentCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                               .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                               ? userArticles.Where(a => a.CommentCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                               .OrderBy(a => a.CommentCount).ToList()
                               : userArticles.Where(a => a.CommentCount >= minCommentCount && a.ViewsCount <= maxCommentCount).Take(takeSize)
                               .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
            }
            return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
            {
                Articles=sortedArticles
            });

        }

       
    }
}
