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
    }
}
