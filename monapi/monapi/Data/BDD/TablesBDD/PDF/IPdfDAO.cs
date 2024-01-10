using monapi.Data;

namespace API.Data.BDD.TablesBDD.PDF
{
    /// <summary>
    /// interface Params DAO, for inset and get  pdf values
    /// </summary>
    public interface IPdfDAO
    {
        /// <summary>
        /// Inserts values into the PDF table
        /// </summary>
        /// <param name="pathPDF">Path to the PDF</param>
        /// <returns>Success or failure message</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public string InsertInPdf(string pathPDF);


        /// <summary>
        /// Get a pdf with the id of the image
        /// </summary>
        /// <param name="id">id of the image</param>
        /// <returns>the path of pdf</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public string GetPdfByIdImg(int id);
    }
}
