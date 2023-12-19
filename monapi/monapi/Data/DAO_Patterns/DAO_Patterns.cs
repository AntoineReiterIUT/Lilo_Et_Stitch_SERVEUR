using API.Data.BDD.TablesBDD;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Xml.Linq;

namespace API.Data.DAO_Patterns
{
    /// <summary>
    /// This class will be executing actions on the directory containing the patterns
    /// </summary>
    public class DAO_Patterns : IDAO_Patterns
    {

        #region attributes
        //The directory in which the patterns are saved
        private string patternsDirectory = "Patterns";
        #endregion


        #region opetations
        public bool CheckIfPatternExist(string name)
        {          
            //Bool to return if it succeeded or not
            bool success;
            try
            {
                //building the whole path
                string patternFolderPath = Path.Combine(patternsDirectory, name);

                //checking if it exists
                success = Directory.Exists(patternFolderPath);
            }
            catch
            { // incase there's a problem, we mark it as false
                success =  false; 
            }

            //returning the result
            return success;
        }

        public bool CreatePattern(string name)
        {
            //Bool to return if it succeeded or not
            bool success;
            try
            {
                //building the whole path
                string patternFolderPath = Path.Combine(patternsDirectory, name);

                //Creating the directory
                Directory.CreateDirectory(patternFolderPath);
                success = true;
            }
            catch
            { // incase there's a problem, we mark it as false
                success = false;
            }

            //returning the result
            return success;
        }
        /// <summary>
        /// used to delete one paterne from the API
        /// </summary>
        /// <param name="name"> the name of the patern that must be deleted </param>
        /// <returns>true if succes false is not</returns>
        public bool DeletePattern(string? name)
        {
            bool success = false;
            if (name != null)
            {
                DirectoryInfo di = new DirectoryInfo(patternsDirectory);
                DirectoryInfo[] subDirectories = di.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    if (name == subDirectory.Name)
                    {
                        foreach (FileInfo file in subDirectory.GetFiles())
                        {
                            file.Delete();
                        }
                        subDirectory.Delete();
                        success = true;
                    }
                }
                
            }
            return success;
        }


        /// <summary>
        /// used to clear all patern from the API
        /// </summary>

        public void DeleteAllPatterns()
        {
            DirectoryInfo di = new DirectoryInfo(patternsDirectory);
            foreach (DirectoryInfo subDirectory in di.GetDirectories())
            {
                foreach (FileInfo file in subDirectory.GetFiles())
                {
                    file.Delete();
                }
                subDirectory.Delete();
            }
            initialise.DeleteAllInBdd();
        }


        public bool AddFile(byte[] file,string dirName,string type)
        {
            //Bool to return if it succeeded or not
            bool success;
            try
            {
                if (file != null)
                {
                    // Building the path & rebuilding the file, ex : /Paterns/NameOfThePattern/NameOfThePattern_PDF.pdf
                    File.WriteAllBytesAsync(Path.Combine(Path.Combine(patternsDirectory, dirName), string.Format($"{dirName}_{type.ToUpper()}.{type}")), file);
                    success = true;
                }
                else
                    success = false;
            }
            catch 
            { 
                success = false;
            }

            //returning the result
            return success;
        }

        public byte[] GetFile(string dirName, string type)
        {
            byte[] fileContent = { 0 };

            try
            {
                // Building the path, ex : /Paterns/NameOfThePattern/NameOfThePattern_PDF.pdf
                string filePath = Path.Combine(Path.Combine(patternsDirectory, dirName), $"{dirName}_{type.ToUpper()}.{type}");

                // Checking if it exists
                if (File.Exists(filePath))
                {
                    // Transforming the file into an array of bytes
                    fileContent = File.ReadAllBytes(filePath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return fileContent;
        }


        #endregion
    }
}
