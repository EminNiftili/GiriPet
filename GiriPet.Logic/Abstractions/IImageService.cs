using GiriPet.Logic.Enums;

namespace GiriPet.Logic.Abstractions
{
    public interface IImageService
    {
        /// <summary>
        /// returned path
        /// </summary>
        string Action(string directory, string base64, ImageAction imageAction, string existingImagePath);

        bool Delete(string path);
    }
}
