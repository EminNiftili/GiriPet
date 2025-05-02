using GiriPet.Logic.Abstractions;

namespace GiriPet.Logic.Services
{
    internal class FileService : IFileService
    {
        public bool Delete(string fullPath)
        {
            try
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }

        public byte[] GetFile(string fullPath)
        {
            try
            {
                if(File.Exists(fullPath))
                {
                    return File.ReadAllBytes(fullPath);
                }
            }
            catch
            {

            }
            return null;
        }

        public string? GetFullPath(string filePath)
        {
            try
            {
                var appDirectory = Directory.GetCurrentDirectory();
                var fullDirectory = $"{appDirectory}\\appFiles\\{filePath}";
                return fullDirectory;
            }
            catch
            {

            }
            return null;
        }

        public string Upload(string directory, byte[] data)
        {
            var fileName = $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}_{Guid.NewGuid().ToString()}.jpg";
            try
            {
                var appDirectory = Directory.GetCurrentDirectory();
                var fullDirectory = $"{appDirectory}\\appFiles\\{directory}";
                if (!Directory.Exists(fullDirectory))
                {
                    Directory.CreateDirectory(fullDirectory);
                }
                File.WriteAllBytes($"{fullDirectory}{fileName}", data);
            }
            catch
            {
                return null;
            }
            return $"{directory}{fileName}";
        }
    }
}
