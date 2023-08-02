using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System.Text.RegularExpressions;

namespace ProgrammersBlog.Mvc.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private const string imgFolder ="img";
        private const string userImagesFolder = "userImages";
        private const string postImagesFolder = "postImages";

        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }

        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}/", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Succes, imageDeletedDto);
              
            }
            else
            {
                return new DataResult<ImageDeletedDto>(ResultStatus.Error, $"Böyle bir resim bulunamdı.",null);   
            }
        }

        public async Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName=null)
        { 
            //eger foldername değişkeni null gelir ise o zaman resim tipine gore (picturetype) klasor adı ataması yapılır.
            folderName ??= pictureType == PictureType.User ? userImagesFolder : postImagesFolder;
            // eger foldername değişkeni ile gelen klasor adı sistemimizde mevcut değise yeni bir klasor olusur.
            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
            }
            // resmin yükleneme sırasındaki ilk adı oldfilename adlı değişkene atanır.
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
            // resimin uzantısı filextension adlı değişkene atanır.
            string fileExtension = Path.GetExtension(pictureFile.FileName);


            Regex regex = new Regex("[*'\",._&#^@]");
            name = regex.Replace(name, string.Empty);


            DateTime dateTime = DateTime.Now;
            //parametre ile gelen degerler kullanılarak yeni bir resim adı olusturulur.
            //çıktı halildegirmnetepe_589_5=38_12_3_10_2022.png
            string newFilename = $"{name}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
            //kendi parametrelerimiz ile sistemimize uygun yeni bir dosya yolu (path) oluşturulur.
            var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFilename);
            // sistemimiz için oluşturulan yeni dosya yoluna resim kopyalanır.
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }
            // resim tipine göre kullanıcı için bir mesaj oluşturulur.
            string message = pictureType==PictureType.User?
                $"{name} adlı kullanıcının resmi yüklenmiştir.":
                $"{name} adlı makalenin resmi yüklenmiştir.";
            return new DataResult<ImageUploadedDto>(ResultStatus.Succes,message,new ImageUploadedDto
            {
                FullName=$"{folderName}/{newFilename}",
                OldName=oldFileName,
                Extension=fileExtension,
                FolderName= folderName,
                Path=path,
                Size=pictureFile.Length

            });
           
        }
    }
}
