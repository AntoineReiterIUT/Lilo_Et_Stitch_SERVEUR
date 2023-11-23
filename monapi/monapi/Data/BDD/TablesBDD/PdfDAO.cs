using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monapi.Data.BDD
{
    /// <summary>
    /// Table PDF in SQL
    /// </summary>
    /// <authors>Mattis Galoppin</authors>
    [Table("PDF")]
    public class PdfDAO
    {
        #region Properties
        /// <summary>
        /// Primary key for PDF table
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Key]
        [Column("ID_PDF")]
        public int ID_PDF { get; set; }

        /// <summary>
        /// Represents the PDF file as a byte array
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Column("THE_PDF")]
        public string THE_PDF { get; set; }

        /// <summary>
        /// Foreign key linking to the ID of the associated image
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Column("ID_IMG")]
        public int ID_IMG { get; set; }
        #endregion
    }
}
