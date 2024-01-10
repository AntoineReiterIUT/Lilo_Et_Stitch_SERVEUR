using API.Data.initialize;


using Microsoft.EntityFrameworkCore;
using monapi.Data;
using monapi.Data.BDD;
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

namespace API.Data.BDD.TablesBDD.Img_Transformed
{
    /// <summary>
    /// Representing the table Img_Transformed in SQL
    /// </summary>
    /// <authors>Mattis GALOPPIN</authors>
    [Table("IMG_TRANSFORMED")]
    public class Img_TransformedDAO : IImg_TransformedDAO
    {
        #region properties

        /// <summary>
        /// Primary key for Img_Transformed table
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Key]
        [Column("ID_IMG")]
        public int ID_IMG { get; set; }

        /// <summary>
        /// Represents the transformed image as a byte array
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Column("IMG")]
        public string IMG { get; set; }

        /// <summary>
        /// Represents the name of the image
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Column("NOM_IMG")]
        public string NOM_IMG { get; set; }

        /// <summary>
        /// Foreign key linking to the ID of the associated parameters
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Column("ID_PARAMS")]
        public int ID_PARAMS { get; set; }

        #endregion


        #region operations

        /// <summary>
        /// Inserts values into the Img_Transformed table
        /// </summary>
        /// <param name="img">The transformed image</param>
        /// <param name="name">The name of the image</param>
        /// <returns>Success or failure message</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public string InsertInImg_Transformed(string img, string name)
        {
            string result = "The image couldn't be inserted";

            //Connection to the database
            using (var context = new MyContext())
            {
                //Creation of the insertion request
                FormattableString sql = $"INSERT INTO Img_Transformed (img, nom_img, id_params) VALUES ({img}, {name}, params_seq.CURRVAL)";

                try
                {
                    //Execute the request
                    context.Database.ExecuteSqlInterpolated(sql);
                    result = "Success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(result);
                }

                return result;
            }
        }


        /// <summary>
        /// get 6 images of the page to display
        /// </summary>
        /// <param name="page">the number of the page to display</param>
        /// <returns>6 images with their attributes</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public List<ImageAttributes> GetImagesTransformed(int page)
        {
            //initialise the list
            List<ImageAttributes> ListImg = new List<ImageAttributes>();

            //initialise the image
            ImageAttributes imgA = new ImageAttributes(-1, "", "", -1);

            //Connection to the database
            using (var context = new MyContext())
            {
                int imagesPerPage = Const.NbPatterns;

                //get the 6 images of the page according to the settings
                var images = context.Img_Transformed
                    .OrderByDescending(img => img.ID_PARAMS) //we order by the id of the parameters
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
        /// Get a list of images researched with a word
        /// </summary>
        /// <param name="word">name of image to search for</param>
        /// <param name="page">the number of the page to get</param>
        /// <returns>a list of images that contain the word</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public List<ImageAttributes> GetImagesBySearch(string word, int page)
        {
            //initialise the list
            List<ImageAttributes> ListImg = new List<ImageAttributes>();

            //initialise the image
            ImageAttributes imgA = new ImageAttributes(-1, "", "", -1);

            //Connection to the database
            using (var context = new MyContext())
            {
                //get the number of images per page
                int imagesPerPage = Const.NbPatterns;

                //try to get in filteredImages all of images who contains the letters
                var filteredImages = context.Img_Transformed
                    .Where(img => img.NOM_IMG.ToLower() //We don't take into account the case
                    .Contains(word.ToLower())) //We select the images who contains the name
                    .OrderBy(img => img.ID_IMG) //we order them by the id of the parameters
                    .Skip(page * imagesPerPage) //We go to the good page
                    .Take(imagesPerPage); //We take the 6 images next

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


        /// <summary>
        /// Get the number of pages available
        /// </summary>
        /// <param name="word">the word used to search</param>
        /// <returns>the number of pages available</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public int GetNumberPage(string word)
        {
            //initialise the number of images
            int nbImages = 0;

            //Connection to the database
            using (var context = new MyContext())
            {
                if (word == "") //There is no word to research
                {
                    //get the number of images
                    nbImages = context.Img_Transformed
                    .OrderBy(img => img.ID_IMG)
                    .Count();
                }

                else //give the number of pages according to the word searched
                {
                    //get the number of images
                    nbImages = context.Img_Transformed
                   .Where(img => img.NOM_IMG.Contains(word)) //We select the images who contains the name
                   .OrderBy(img => img.ID_IMG)
                   .Count();
                }
            }

            //return the number of pages
            return (int)Math.Ceiling(nbImages / (double)Const.NbPatterns); //return the good number of pages
        }

        #endregion
    }
}
