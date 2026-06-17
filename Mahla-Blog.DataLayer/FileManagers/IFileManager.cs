using Microsoft.AspNetCore.Http;

namespace Mahla_Blog.CoreLayer.FileManagers
{
    public interface IFileManager
    {
        public string SaveFileAndReturnName(IFormFile file, string savePath);
    }
}