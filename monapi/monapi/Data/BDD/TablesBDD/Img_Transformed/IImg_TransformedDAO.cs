using monapi.Data.BDD;

namespace API.Data.BDD.TablesBDD.Img_Transformed
{
    /// <summary>
    /// interface of the Img_TransformedDAO class to get and set the transformed images
    /// </summary>
    public interface IImg_TransformedDAO
    {
        /// <summary>
        /// Inserts values into the Img_Transformed table
        /// </summary>
        /// <param name="img">The transformed image</param>
        /// <param name="name">The name of the image</param>
        /// <returns>Success or failure message</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public string InsertInImg_Transformed(string img, string name);


        /// <summary>
        /// Get 6 images of the page to display
        /// </summary>
        /// <param name="page">the number of the page to display</param>
        /// <returns>6 images with attributes</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public List<ImageAttributes> GetImagesTransformed(int page);


        /// <summary>
        /// Get a list of images researched with a word
        /// </summary>
        /// <param name="word">name of image to search for</param>
        /// <param name="page">the number of the page to get</param>
        /// <returns>a list of images that contain the word</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public List<ImageAttributes> GetImagesBySearch(string word, int page);


        /// <summary>
        /// Get the number of pages available depending on the search word
        /// </summary>
        /// <param name="word">the word used to search</param>
        /// <returns>the number of pages available</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public int GetNumberPage(string word);
    }
}
