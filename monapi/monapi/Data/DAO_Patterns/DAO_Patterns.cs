using API.Data.initialize;

namespace API.Data.DAO_Patterns
{
    /// <summary>
    /// This class will be executing actions on the directory containing the patterns
    /// </summary>
    public class DAO_Patterns : IDAO_Patterns
    {
        #region operations

        /// <summary>
        /// Will check in the directory (API) if a pattern with that name exists or not
        /// </summary>
        /// <param name="name">The name of the pattern to check</param>
        /// <returns>If the pattern exists or not</returns>
        /// <author>Maxime LAFFAYE</author>
        public bool CheckIfPatternExist(string name)
        {          
            //Bool to return if it succeeded or not
            bool success = false;
            try
            {
                //building the whole path
                string patternFolderPath = Path.Combine(Const.patternsDirectory, name);

                //checking if it exists
                success = Directory.Exists(patternFolderPath);
            }
            catch
            { //In the case where there's a problem, we mark the success as false
                success =  false; 
            }

            //returning the result
            return success;
        }


        /// <summary>
        /// Will create a directory with the name of the pattern. I'll contain the csv, pdf and image after
        /// </summary>
        /// <param name="name">The name of the pattern</param>
        /// <returns>Success or not</returns>
        /// <author>Maxime LAFFAYE</author>
        public bool CreatePattern(string name)
        {
            //Bool to return if it succeeded or not
            bool success = false;
            try
            {
                //building the whole path
                string patternFolderPath = Path.Combine(Const.patternsDirectory, name);

                //Creating the directory
                Directory.CreateDirectory(patternFolderPath);
                success = true;
            }
            catch
            { //incase there's a problem, we mark it as false
                success = false;
            }

            //returning the result
            return success;
        }


        /// <summary>
        /// Adds the file (pdf, img or csv) to the directory
        /// </summary>
        /// <param name="file">File, as an array of bytes</param>
        /// <param name="dirName">Name of the dir in which the file should be rebuilt</param>
        /// <param name="type">Type of the file to rebuild</param>
        /// <returns>Result of the rebuild</returns>
        /// <author>Maxime LAFFAYE</author>
        public bool AddFile(byte[] file,string dirName,string type)
        {
            //Bool to return if it succeeded or not
            bool success;
            try
            {
                if (file != null)
                {
                    //Building the path & rebuilding the file, ex : /Paterns/NameOfThePattern/NameOfThePattern_PDF.pdf
                    File.WriteAllBytesAsync(Path.Combine(Path.Combine(Const.patternsDirectory, dirName), string.Format($"{dirName}_{type.ToUpper()}.{type}")), file);
                    
                    //If the file is not null, we mark the result as true
                    success = true;
                }
                else
                    //If the file is null, we mark the result as false
                    success = false;
            }
            catch 
            { 
                success = false;
            }

            //returning the result
            return success;
        }


        /// <summary>
        /// Used to get a file from a pattern
        /// </summary>
        /// <param name="dirName">The name of the pattern (also the name of the directory)</param>
        /// <param name="type">The type of the file</param>
        /// <returns>The file content as an array of bytes</returns>
        /// <author>Maxime LAFFAYE</author>
        public byte[] GetFile(string dirName, string type)
        {
            //Array of bytes to return
            byte[] fileContent = { 0 };

            try
            {
                //Building the path, ex : /Paterns/NameOfThePattern/NameOfThePattern_PDF.pdf
                string filePath = Path.Combine(Path.Combine(Const.patternsDirectory, dirName), $"{dirName}_{type.ToUpper()}.{type}");

                //Checking if it exists
                if (File.Exists(filePath))
                {
                    //Transforming the file into an array of bytes
                    fileContent = File.ReadAllBytes(filePath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return fileContent;
        }


        /// <summary>
        /// Used to delete one pattern from the API
        /// </summary>
        /// <param name="name"> the name of the pattern that must be deleted </param>
        /// <returns>true if succes false is not</returns>
        /// <exception cref="Exception">exception that may be triggered when deleting an empty pattern folder</exception>
        /// <author>Antoine REITER</author>
        public bool DeletePattern(string? name)
        {
            try
            {
                //Bool to return if it succeeded or not
                bool success = false;

                //Checking if the name is not null
                if (name != null)
                {
                    //Building the path
                    DirectoryInfo di = new DirectoryInfo(Const.patternsDirectory);
                    DirectoryInfo[] subDirectories = di.GetDirectories();

                    //for each subdirectory in the patterns directory
                    foreach (DirectoryInfo subDirectory in subDirectories)
                    {
                        //if the name of the subdirectory is the same as the name of the pattern
                        if (name == subDirectory.Name)
                        {
                            //delete all the subdirectory files
                            foreach (FileInfo file in subDirectory.GetFiles())
                            {
                                file.Delete();
                            }

                            //delete the subdirectory
                            subDirectory.Delete();
                            success = true;
                        }
                    }

                }
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception("It's not possible to delete an empty pattern folder : " + ex.Message);
            }
        }


        /// <summary>
        /// Used to clear all pattern from the API
        /// </summary>
        /// <author>Antoine REITER</author>
        public void DeleteAllPatterns()
        {
            try
            {
                //Delete all the data in the database
                initialise.DeleteAll();

                //Delete all the files in the patterns directory
                DirectoryInfo di = new DirectoryInfo(Const.patternsDirectory);
                foreach (DirectoryInfo subDirectory in di.GetDirectories())
                {
                    //delete all the subdirectory files
                    foreach (FileInfo file in subDirectory.GetFiles())
                    {
                        file.Delete();
                    }
                    //delete the subdirectory
                    subDirectory.Delete();
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                //If the directory doesn't exist, we create it ?
                Directory.CreateDirectory(Const.patternsDirectory);
            }
        }

        #endregion
    }
}
