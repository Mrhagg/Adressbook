namespace Adressbook.Interfaces
{
    public interface IFileService
    {
    
        bool SaveContentToFile(string content, string filePath);


        string GetContentFromFile(string filePath);
        
    }
}