using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Enums;

namespace GiriPet.Logic.Services
{
    public class ImageService : IImageService
    {
        private readonly IFileService _fileService;

        public ImageService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public string Action(string directory, string base64, ImageAction imageAction, string existingImagePath)
        {
            if (imageAction == ImageAction.Updated)
            {
                var imageContent = Convert.FromBase64String(base64);
                return _fileService.Upload(directory, imageContent);
            }
            else if (imageAction == ImageAction.Removed && _fileService.Delete(existingImagePath))
            {
                return null;
            }
            else if (imageAction == ImageAction.NoAction)
            {
                return existingImagePath;
            }
            return existingImagePath;
        }

        public bool Delete(string path)
        {
            return _fileService.Delete(path);
        }
    }
}
