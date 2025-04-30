using GiriPet.Logic.Abstractions;

namespace GiriPet.Logic.Services
{
    internal class FileService : IFileService
    {
        public byte[] GetFile(string fullPath)
        {
            throw new NotImplementedException();
        }

        public string GetFullPath(string filePath)
        {
            throw new NotImplementedException();
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
            return fileName;
        }
    }
}
