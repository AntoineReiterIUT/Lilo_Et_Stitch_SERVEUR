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
        /// Adds the pdf to the directory
        /// </summary>
        /// <param name="PDF">PDF, as an array of bytes</param>
        /// <param name="dirName">Name of the dir in which the pdf should be rebuilt</param>
        /// <returns>Result of the rebuild</returns>
        /// <author>Antoine REITER</author>
        public bool AddPDF(byte[] PDF, string dirName);


        /// <summary>
        /// Adds the palette to the directory
        /// </summary>
        /// <param name="CSV">CSV, as an array of bytes</param>
        /// <param name="dirName">Name of the dir in which the csv should be rebuilt</param>
        /// <returns>Result of the rebuild</returns>
        /// <author>Antoine REITER</author>
        public bool AddCSV(byte[] PDF, string dirName);


        /// <summary>
        /// Adds the image to the directory
        /// </summary>
        /// <param name="IMG">The image, as an array of bytes</param>
        /// <param name="dirName">Name of the dir in which the image should be rebuilt</param>
        /// <returns>Result of the rebuild</returns>
        /// <author>Antoine REITER</author>
        public bool AddIMG(byte[] IMG, string dirName);
    }
}
