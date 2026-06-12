using Microsoft.AspNetCore.Http;

namespace Mahla_Blog.CoreLayer.FileManagers
{
    public interface IFileManager
    {
        public string SaveFile(IFormFile file, string savePath);
    }
}