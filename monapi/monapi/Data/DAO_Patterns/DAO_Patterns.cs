using Microsoft.AspNetCore.Authentication.OAuth;

namespace API.Data.DAO_Patterns
{
    /// <summary>
    /// This class will be executing actions on the directory containing the patterns
    /// </summary>
    public class DAO_Patterns : IDAO_Patterns
    {

        #region opetations
        public bool CheckIfPatternExist(string name)
        {
            //The directory in which the patterns are saved
            string patternsDirectory = "Patterns";

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
            //The directory in which the patterns are saved
            string patternsDirectory = "Patterns";

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

        #endregion
    }
}
