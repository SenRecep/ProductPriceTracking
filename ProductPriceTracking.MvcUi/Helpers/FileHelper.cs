using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProductPriceTracking.MvcUi.Enums;
using ProductPriceTracking.MvcUi.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPriceTracking.MvcUi.Helpers
{
    public class FileHelper
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileHelper(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<UploadModel> UploadFile(IFormFile formFile, string destFolder, params string[] fileTypes)
        {
            if (formFile == null)
            {
                return new UploadModel()
                {
                    ErrorMessage = "Dosya Bulunamadı",
                    UploadState = UploadState.NotExist
                };
            }

            if (!fileTypes.Contains(formFile.ContentType))
            {
                return new UploadModel()
                {
                    ErrorMessage = "Uyumsuz dosya tipi",
                    UploadState = UploadState.Error
                };
            }

            string newName = $"{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}";
            string folderPath = Path.Combine(webHostEnvironment.WebRootPath, destFolder);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string path = Path.Combine(folderPath, newName);
            FileStream stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);

            return new UploadModel()
            {
                NewName = newName,
                UploadState = UploadState.Success
            };
        }

        public async Task<UploadModel> UploadImage(IFormFile formFile, string destFolder)
        {
            return await UploadFile(formFile, destFolder, "image/jpeg", "image/png");
        }
        public void UploadedFileDelete(string file, string destFolder)
        {
            string folderPath = Path.Combine(webHostEnvironment.WebRootPath, destFolder);
            string path = Path.Combine(folderPath, file);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public FileModel GetFile(string file, string destFolder)
        {
            if (string.IsNullOrWhiteSpace(file) || string.IsNullOrEmpty(file))
            {
                return new FileModel() { IsExist = false };
            }

            string vpath = Path.Combine(destFolder, file);
            string path = Path.Combine(webHostEnvironment.WebRootPath, vpath);
            if (!File.Exists(path))
            {
                return new FileModel() { IsExist = false };
            }

            return new FileModel()
            {
                Path = vpath,
                IsExist = true
            };
        }
    }
}
