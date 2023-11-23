using Microsoft.EntityFrameworkCore;
using monapi.Data;
using monapi.Data.BDD;
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
    /// Table PARAMS in SQL
    /// </summary>
    /// <authors>Mattis Galoppin</authors>
    [Table("PARAMS")]
    public class Params
    {
        #region Properties
        /// <summary>
        /// Primary key for PARAMS table
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Key]
        [Column("ID_PARAMS")]
        public int ID_PARAMS { get; set; }

        /// <summary>
        /// Represents the step of the image
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Column("STEP")]
        public int STEP { get; set; }

        /// <summary>
        /// Represents the number of colors used
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Column("NB_COLORS")]
        public int NB_COLORS { get; set; }

        /// <summary>
        /// Represents the color of the grid
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Column("GRID_COLOR")]
        public string GRID_COLOR { get; set; }

        /// <summary>
        /// Represents the DMC palette
        /// </summary>
        /// 
        [Column("PALETTEDMC")]
        public string PALETTEDMC { get; set; }

        #endregion
        #region Methods
        /// <summary>
        /// Inserts data into the Params table
        /// </summary>
        /// <param name="step">Step of the image</param>
        /// <param name="nbColor">Number of colors used</param>
        /// <param name="gridColor">Color of the grid</param>
        /// <param name="csv">Palette DMC</param>
        /// <returns>Success or failure message</returns>
        public string InsertInParams(int step, int nbColor, string gridColor, string csv)
        {
            string function = "The data was not inserted";
            using (var context = new MyContext())
            {
                FormattableString sql = $"INSERT INTO Params (step, nb_colors, grid_color, paletteDMC) VALUES ({step},{nbColor},{gridColor},{csv})";
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
        #endregion

    }
}
