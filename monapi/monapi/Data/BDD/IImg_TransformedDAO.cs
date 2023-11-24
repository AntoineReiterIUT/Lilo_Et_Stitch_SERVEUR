using monapi.Data.BDD;

namespace API.Data.BDD
{
    /// <summary>
    /// interface Img_TransformedDAO for insert and get values
    /// </summary>
    public interface IImg_TransformedDAO
    {
        #region Methods
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
        /// <returns>6 images with attributies</returns>
        /// <authors>Mattis Galoppin</authors>
        public List<ImageAttributes> GetImagesTransformed(int page);
        #endregion
    }
}
