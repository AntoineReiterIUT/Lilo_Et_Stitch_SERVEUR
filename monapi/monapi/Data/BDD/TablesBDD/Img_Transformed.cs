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

namespace monapi.Data.BDD
{
    /// <summary>
    /// Table Img_Transformed in SQL
    /// </summary>
    /// <authors>Mattis Galoppin</authors>
    [Table("IMG_TRANSFORMED")]
    public class Img_Transformed
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
            string function = "The data was not inserted";

            // Insertion
            using (var context = new MyContext())
            {
                FormattableString sql = $"INSERT INTO Img_Transformed (img, nom_img, id_params) VALUES ({img}, {name}, params_seq.CURRVAL)";

                try
                {
                    context.Database.ExecuteSqlInterpolated(sql);
                    function = "Success";
                }
                catch (Exception ex)
                {

                }
                return function;
            }
        }
        #endregion

    }
}
