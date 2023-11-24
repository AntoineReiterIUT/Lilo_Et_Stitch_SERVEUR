using Microsoft.AspNetCore.Authentication.OAuth;
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


        public bool AddPDF(byte[] PDF,string dirName)
        {
            //Bool to return if it succeeded or not
            bool success;
            try
            {
                if (PDF != null)
                {
                    // Building the path & rebuilding the PDF, ex : /Paterns/NameOfThePattern/NameOfThePattern_PDF.pdf
                    File.WriteAllBytesAsync(Path.Combine(Path.Combine(patternsDirectory, dirName), string.Format($"{dirName}_PDF.pdf")), PDF);
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


        public bool AddCSV(byte[] CSV, string dirName)
        {
            //Bool to return if it succeeded or not
            bool success;
            try
            {
                if (CSV != null)
                {
                    // Building the path & rebuilding the CSV, ex : /Paterns/NameOfThePattern/NameOfThePattern_CSV.csv
                    File.WriteAllBytesAsync(Path.Combine(Path.Combine(patternsDirectory, dirName), string.Format($"{dirName}_CSV.csv")), CSV);
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


        public bool AddIMG(byte[] IMG, string dirName)
        {
            //Bool to return if it succeeded or not
            bool success;
            try
            {
                if (IMG != null)
                {
                    // Building the path & rebuilding the CSV, ex : /Paterns/NameOfThePattern/NameOfThePattern_IMG.png
                    File.WriteAllBytesAsync(Path.Combine(Path.Combine(patternsDirectory, dirName), string.Format($"{dirName}_IMG.png")), IMG);
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
        #endregion
    }
}
