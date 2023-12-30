namespace Adressbook.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Saves the content to a specified filepath.
        /// </summary>
        /// <param name="content">enter the content as a string</param>
        /// /// <param name="filePath">enters the filepath of your choice</param>
        /// <returns>If the filepath exists and is saved returns true, else fails. </returns>
        bool SaveContentToFile(string content, string filePath);

        /// <summary>
        /// Gets content from a specific filepath
        /// </summary>
        /// <param name="filePath">enters the filepath of your choice</param>
        /// <returns>returns as a string if the file is valid/exists, else if fails returns null.</returns>
        string GetContentFromFile(string filePath);
        
    }
}