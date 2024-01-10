namespace API.Data.DAO_Patterns
{
    /// <summary>
    /// This interface will be used to structure the link between the API and the DAO_Patterns
    /// </summary>
    public interface IDAO_Patterns
    {


        /// <summary>
        /// Will check in the directory (API) if a pattern with that name exists or not
        /// </summary>
        /// <param name="name">Name of the potentially new pattern</param>
        /// <returns>If the pattern exists or not</returns>
        /// <author>Maxime LAFFAYE</author>
        public bool CheckIfPatternExist(string name);


        /// <summary>
        /// Will create a directory with the name of the pattern. I'll contain the csv, pdf and image after
        /// </summary>
        /// <param name="name">The name of the pattern</param>
        /// <returns>Success or not</returns>
        /// <author>Maxime LAFFAYE</author>
        public bool CreatePattern(string name);


        /// <summary>
        /// Adds the file (pdf, img or csv) to the directory
        /// </summary>
        /// <param name="file">File, as an array of bytes</param>
        /// <param name="dirName">Name of the dir in which the file should be rebuilt</param>
        /// <param name="type">Type of the file to rebuild</param>
        /// <returns>Result of the rebuild</returns>
        /// <author>Maxime LAFFAYE</author>
        public bool AddFile(byte[] file, string dirName, string type);


        /// <summary>
        /// Used to get a file from a pattern
        /// </summary>
        /// <param name="dirName">Name of the pattern</param>
        /// <param name="type">Type of the file to look for</param>
        /// <returns>Array of bytes</returns>
        /// <author>Maxime LAFFAYE</author>
        public byte[] GetFile(string dirName, string type);


        /// <summary>
        /// Used to delete one pattern from the API
        /// </summary>
        /// <param name="name"> the name of the pattern that must be deleted </param>
        /// <returns>true if succes false is not</returns>
        /// <exception cref="Exception">exception that may be triggered when deleting an empty pattern folder</exception>
        /// <author>Antoine REITER</author>
        public bool DeletePattern(string? name);


        /// <summary>
        /// Used to clear all pattern from the API
        /// </summary>
        /// <author>Antoine REITER</author>
        public void DeleteAllPatterns();
    }
}
