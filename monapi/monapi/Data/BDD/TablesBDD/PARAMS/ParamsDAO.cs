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

namespace API.Data.BDD.TablesBDD.PARAMS
{
    /// <summary>
    /// Class representing the table PARAMS in SQL
    /// </summary>
    /// <authors>Mattis GALOPPIN</authors>
    [Table("PARAMS")]
    public class ParamsDAO : IParamsDAO
    {
        #region Properties

        /// <summary>
        /// Primary key for PARAMS table
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Key]
        [Column("ID_PARAMS")]
        public int ID_PARAMS { get; set; }

        /// <summary>
        /// Represents the step of the image
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Column("STEP")]
        public int STEP { get; set; }

        /// <summary>
        /// Represents the number of colors used
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Column("NB_COLORS")]
        public int NB_COLORS { get; set; }

        /// <summary>
        /// Represents the color of the grid
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Column("GRID_COLOR")]
        public string GRID_COLOR { get; set; }

        /// <summary>
        /// Represents the DMC palette
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Column("PALETTEDMC")]
        public string PALETTEDMC { get; set; }

        #endregion


        #region operations

        /// <summary>
        /// Inserts data into the Params table
        /// </summary>
        /// <param name="step">Step of the image</param>
        /// <param name="nbColor">Number of colors used</param>
        /// <param name="gridColor">Color of the grid</param>
        /// <param name="csv">Palette DMC</param>
        /// <returns>Success or failure message</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public string InsertInParams(int step, int nbColor, string gridColor, string csv)
        {
            string function = "The data was not inserted";

            //Connection to the database
            using (var context = new MyContext())
            {
                //Creating the SQL query
                FormattableString sql = $"INSERT INTO Params (step, nb_colors, grid_color, paletteDMC) VALUES ({step},{nbColor},{gridColor},{csv})";
                try
                {
                    //Executing the query
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
        /// Returns the parameters of an image with its ID
        /// </summary>
        /// <param name="id">ID of the image</param>
        /// <returns>Parameter attributes</returns>
        /// <authors>Mattis GALOPPIN</authors>
        public ParamAttributes GetParamsByIdParam(int id)
        {
            //Initialization of ParamAttributes
            ParamAttributes pA = new ParamAttributes(-1, -1, -1, "", "");

            //Connection to the database
            using (var context = new MyContext())
            {
                //Keep data of a row with the specified ID
                var rep = context.Params
                    .Where(p => p.ID_PARAMS == id)
                    .FirstOrDefault();

                if (rep != null) //Row found
                {
                    //Create a record of parameter attributes with the returned row
                    pA = new ParamAttributes(rep.ID_PARAMS, rep.STEP, rep.NB_COLORS, rep.GRID_COLOR, rep.PALETTEDMC);
                }
            }

            return pA;
        }

        #endregion
    }
}
