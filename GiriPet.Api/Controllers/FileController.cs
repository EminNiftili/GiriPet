using GiriPet.Logic.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace GiriPet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("/{name}")]
        public async Task<IActionResult> DownloadImage(string name)
        {
            var filePath = _fileService.GetFullPath(name);
            var fileBytes = _fileService.GetFile(filePath);
            // Content-Type avtomatik tapmaq üçün:
            var contentType = GetContentType(filePath);

            return File(fileBytes, contentType, name);
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream"; // tapılmasa default
            }
            return contentType;
        }
    }
}
