using Microsoft.EntityFrameworkCore;
using monapi.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.BDD.TablesBDD.PDF
{
    /// <summary>
    /// Represents the PDF table in SQL
    /// </summary>
    /// <authors>Mattis GALOPPIN</authors>
    [Table("PDF")]
    public class PdfDAO : IPdfDAO
    {
        #region Properties

        /// <summary>
        /// Primary key for PDF table
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Key]
        [Column("ID_PDF")]
        public int ID_PDF { get; set; }

        /// <summary>
        /// Represents the PDF file as a byte array
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Column("THE_PDF")]
        public string THE_PDF { get; set; }

        /// <summary>
        /// Foreign key linking to the ID of the associated image
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Column("ID_IMG")]
        public int ID_IMG { get; set; }

        #endregion


        #region operations

        /// <summary>
        /// Inserts values into the PDF table
        /// </summary>
        /// <param name="pathPDF">Path to the PDF</param>
        /// <returns>Success or failure message</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public string InsertInPdf(string pathPDF)
        {
            string function = "The PDF couldn't be inserted";
            using (var context = new MyContext())
            {
                FormattableString sql = $"INSERT INTO Pdf (the_pdf, id_img) VALUES ({pathPDF}, IMG_TRANSFORMED_SEQ.CURRVAL)";
                try
                {
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
        /// Get a pdf with the id of the image
        /// </summary>
        /// <param name="id">id of the image</param>
        /// <returns>the path of pdf</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public string GetPdfByIdImg(int id)
        {
            string path = "";

            //Connection to the database
            using (var context = new MyContext())
            {
                // Keep data of a row with the specified ID
                var rep = context.Pdf
                    .Where(p => p.ID_IMG == id)
                    .FirstOrDefault();

                if (rep != null) //we find a row
                {
                    path = rep.THE_PDF; //wee load a pdf
                }
            }

            return path;
        }

        #endregion
    }
}
