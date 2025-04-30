namespace GiriPet.Logic.Abstractions
{
    public interface IFileService
    {
        string Upload(string directory, byte[] data);
        byte[] GetFile(string fullPath);
        string GetFullPath(string filePath);

    }
}
