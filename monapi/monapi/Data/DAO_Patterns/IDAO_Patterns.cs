namespace API.Data.DAO_Patterns
{
    /// <summary>
    /// This interface will be used to structure the link between the API and the DAO_Patterns
    /// </summary>
    public interface IDAO_Patterns
    {


        /// <summary>
        /// Will check in the directory if a pattern with that name exists or not
        /// </summary>
        /// <param name="name">Name of the potentially new pattern</param>
        /// <returns>A boolean</returns>
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
        /// <param name="PDF">File, as an array of bytes</param>
        /// <param name="dirName">Name of the dir in which the file should be rebuilt</param>
        /// <returns>Result of the rebuild</returns>
        /// <author>Antoine REITER</author>
        public bool AddFile(byte[] file, string dirName, string type);


        /// <summary>
        /// Will return the file, as an array of bytes
        /// </summary>
        /// <param name="dirName">Name of the pattern</param>
        /// <param name="type">Type of the file to look for</param>
        /// <returns>Array of bytes</returns>
        /// <author>Maxime LAFFAYE</author>
        public byte[] GetFile(string dirName, string type);

        public bool DeletePattern(string? name);

        public void DeleteAllPatterns();
    }
}
