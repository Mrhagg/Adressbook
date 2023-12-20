using System.Diagnostics;

namespace Adressbook.Services;

public interface IFileService
{
    /// <summary>
    /// Saves the content to a specified filepath.
    /// </summary>
    /// <param name="content">enter the content as a string</param>
    /// /// <param name="filePath">enters the filepath of your choice</param>
    /// <returns>If the filepath exists and is saved returns true, else fails. </returns>
    bool SaveContentToFile (string content);

    /// <summary>
    /// Gets content from a specific filepath
    /// </summary>
    /// <param name="filePath">enters the filepath of your choice</param>
    /// <returns>returns as a string if the file is valid/exists, else if fails returns null.</returns>
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
