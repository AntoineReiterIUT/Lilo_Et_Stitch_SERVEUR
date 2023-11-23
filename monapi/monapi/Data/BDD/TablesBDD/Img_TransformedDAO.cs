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
    public class Img_TransformedDAO
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
    }
}
