namespace GiriPet.Logic.Abstractions
{
    public interface IFileService
    {
        bool Delete(string fullPath);
        string Upload(string directory, byte[] data);
        bool AppendText(string directory, string fileName, string message);
        byte[] GetFile(string fullPath);
        string GetFullPath(string filePath);

    }
}
