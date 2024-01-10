using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monapi.Data.BDD
{
    /// <summary>
    /// Represents a class for storing parameter attributes.
    /// </summary>
    public class ParamAttributes
    {
        #region attributes

        private int id;
        private int step;
        private int nbColor;
        private string palette;
        private string gridColor;

        #endregion


        #region properties

        /// <summary>
        /// Property : Gets or sets the id.
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Property : Gets or sets the step.
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        public int Step
        {
            get { return step; }
            set { step = value; }
        }

        /// <summary>
        /// Property : Gets or sets the number of color.
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        public int NbColor
        {
            get { return nbColor; }
            set { nbColor = value; }
        }

        /// <summary>
        /// Property : Gets or sets the grid color.
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        public string GridColor
        {
            get { return gridColor; }
            set { gridColor = value; }
        }

        /// <summary>
        /// Property : Gets or sets the color palette.
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        public string ColorPalette
        {
            get { return palette; }
            set { palette = value; }
        }

        #endregion


        #region operations

        /// <summary>
        /// Initializes a new instance of the ParamAttributes class.
        /// </summary>
        /// <param name="id">The Id of the pattern</param>
        /// <param name="step">The Step value</param>
        /// <param name="nbColor">The number of colors</param>
        /// <param name="gridColor">The color of the grid</param>
        /// <param name="colorPalette">The color palette values</param>
        /// <authors>Mattis GALOPPIN</authors>
        public ParamAttributes(int id, int step, int nbColor, string gridColor, string colorPalette)
        {
            //initialization
            this.id = id;
            this.step = step;
            this.nbColor = nbColor;
            this.gridColor = gridColor;
            palette = colorPalette;
        }

        #endregion
    }
}
