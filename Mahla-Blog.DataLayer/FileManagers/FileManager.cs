using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Mahla_Blog.CoreLayer.FileManagers
{
    public class FileManager : IFileManager
    {
        public string SaveFile(IFormFile file, string savePath)
        {
            if (file == null)
                throw new Exception("File Is Null!");

            var fileName = $"{Guid.NewGuid()}{file.FileName}";

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), savePath.Replace("/", "\\"));

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var fullPath = Path.Combine(fileName + filePath);

            using var stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);


            return fileName;
        }
    }
}

