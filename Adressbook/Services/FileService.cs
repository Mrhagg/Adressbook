using System.Diagnostics;

namespace Adressbook.Services;

public interface IFileService
{
    bool SaveContentToFile (string content);

    string GetContentFromFile();
}


public class FileService : IFileService
{
    private string _filePath;
    public FileService(string filePath) {  _filePath = filePath; }

    public bool SaveContentToFile(string content)
    {
        try
        {

            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);
            }
          

            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return false;
        
    }
    public string GetContentFromFile()
    {
        try
        {

                using (StreamReader streamReader = new StreamReader(_filePath))
                {
                   return streamReader.ReadToEnd();
                }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
}
