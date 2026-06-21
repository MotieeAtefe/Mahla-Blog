using Mahla_Blog.CoreLayer.FileManagers;
using Mahla_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahla_Blog.Web.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        private readonly IFileManager _fileManager;

        public UploadController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }
        [Route("/Upload/Article")]
        public IActionResult UploadArticleImage(IFormFile upload)
        {
            if (upload == null)
                return BadRequest();
            var imageName = _fileManager.SaveFileAndReturnName(upload, Directories.PostContentImage);
            return Json(new { Uploaded = true, Url = Directories.GetPostContentImage(imageName) });
        }
    }
}
