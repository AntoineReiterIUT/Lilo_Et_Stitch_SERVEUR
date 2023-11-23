using monapi.Data.BDD;
using System.Drawing.Imaging;

namespace API.Data.BDD
{
    public interface IREQUEST
    {
        /// <summary>
        /// Inserts values into the Img_Transformed table
        /// </summary>
        /// <param name="img">The transformed image</param>
        /// <param name="name">The name of the image</param>
        /// <returns>Success or failure message</returns>
        /// <authors>Mattis Galoppin</authors>
        public string InsertInImg_Transformed(string img, string name);

        /// <summary>
        /// get 6 images of the page to display
        /// </summary>
        /// <param name="page">the number of the page to display</param>
        /// <returns>6 images with attributs</returns>
        public List<monapi.Data.BDD.ImageAttributes> GetImagesTransformed(int page);

        /// <summary>
        /// Returns the parameters of an image with its ID
        /// </summary>
        /// <param name="id">ID of the image</param>
        /// <returns>Parameter attributes</returns>
        /// <author>Mattis Galoppin</author>
        public ParamAttributes GetParamsByIdParam(int id);
        /// <summary>
        /// Inserts data into the Params table
        /// </summary>
        /// <param name="step">Step of the image</param>
        /// <param name="nbColor">Number of colors used</param>
        /// <param name="gridColor">Color of the grid</param>
        /// <param name="csv">Palette DMC</param>
        /// <returns>Success or failure message</returns>
        public string InsertInParams(int step, int nbColor, string gridColor, string csv);

        /// <summary>
        /// Inserts values into the PDF table
        /// </summary>
        /// <param name="pathPDF">Path to the PDF</param>
        /// <returns>Success or failure message</returns>
        /// <authors>Mattis Galoppin</authors>
        public string InsertInPdf(string pathPDF);

        /// <summary>
        /// Get a pdf with the id of the image
        /// </summary>
        /// <param name="id">id of the image</param>
        /// <returns>the path of pdf</returns>
        public string GetPdfByIdImg(int id);


    }
}
