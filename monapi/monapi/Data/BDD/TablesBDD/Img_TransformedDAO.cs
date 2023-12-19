using API.Data.BDD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace monapi.Data.BDD
{
    /// <summary>
    /// Table Img_Transformed in SQL
    /// </summary>
    /// <authors>Mattis Galoppin</authors>
    [Table("IMG_TRANSFORMED")]
    public class Img_TransformedDAO : IImg_TransformedDAO
    {
        #region Properties

        /// <summary>
        /// Primary key for Img_Transformed table
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Key]
        [Column("ID_IMG")]
        public int ID_IMG { get; set; }

        /// <summary>
        /// Represents the transformed image as a byte array
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Column("IMG")]
        public string IMG { get; set; }

        /// <summary>
        /// Represents the name of the image
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Column("NOM_IMG")]
        public string NOM_IMG { get; set; }

        /// <summary>
        /// Foreign key linking to the ID of the associated parameters
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Column("ID_PARAMS")]
        public int ID_PARAMS { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Inserts values into the Img_Transformed table
        /// </summary>
        /// <param name="img">The transformed image</param>
        /// <param name="name">The name of the image</param>
        /// <returns>Success or failure message</returns>
        /// <authors>Mattis Galoppin</authors>
        public string InsertInImg_Transformed(string img, string name)
        {
            string function = "The image couldn't be inserted";


            using (var context = new MyContext())
            {
                //creation insertion request
                FormattableString sql = $"INSERT INTO Img_Transformed (img, nom_img, id_params) VALUES ({img}, {name}, params_seq.CURRVAL)";

                try
                {
                    // execute request
                    context.Database.ExecuteSqlInterpolated(sql);
                    function = "Success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(function);
                }
                return function;
            }
        }
        /// <summary>
        /// get 6 images of the page to display
        /// </summary>
        /// <param name="page">the number of the page to display</param>
        /// <returns>6 images with attributes</returns>
        /// <authors>Mattis Galoppin</authors>
        public List<ImageAttributes> GetImagesTransformed(int page)
        {
            List<ImageAttributes> ListImg = new List<ImageAttributes>();
            ImageAttributes imgA = new ImageAttributes(-1, "", "", -1);
            using (var context = new MyContext())
            {
                int imagesPerPage = 6;

                // Numéro de la première image à récupérer
                int offset = context.Img_Transformed.Count(); // Vous pouvez ajuster cela en fonction de votre critère de tri

                var images = context.Img_Transformed 
                    .OrderBy(img => img.ID_IMG)
                    .Skip(page * imagesPerPage) // we go to the good image
                    .Take(imagesPerPage); //we take the 6 images next

                if (images != null) //the row is not null
                {
                    foreach (var img in images) //add every image in the list
                    {
                        imgA = new ImageAttributes(img.ID_IMG, img.NOM_IMG, img.IMG, img.ID_PARAMS);
                        ListImg.Add(imgA);
                    }
                }

            }
            return ListImg;
        }
        /// <summary>
        /// get a list of images research with a word
        /// </summary>
        /// <param name="word">name of image to search</param>
        /// <returns>a list of images that contain the word</returns>
        public List<ImageAttributes> GetImagesBySearch(string word)
        {
            //initialise the list
            List<ImageAttributes> ListImg = new List<ImageAttributes>();
            ImageAttributes imgA = new ImageAttributes(-1, "", "", -1);

            using (var context = new MyContext())
            {
                //try to recup in filteredImages all of images who contains the word
                var filteredImages = context.Img_Transformed
                .Where(img => img.NOM_IMG.Contains(word))
                .OrderBy(img => img.ID_IMG);

                if (filteredImages != null) //the row is not null
                {
                    foreach (var img in filteredImages) //add every image in the list
                    {
                        imgA = new ImageAttributes(img.ID_IMG, img.NOM_IMG, img.IMG, img.ID_PARAMS);
                        ListImg.Add(imgA);
                    }
                }
            }
            return ListImg;
            
        }
        #endregion
    }
}
