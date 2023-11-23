using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBDD.RecordAttributes
{
    /// <summary>
    /// Represents a class for storing parameter attributes.
    /// </summary>
    public class ParamAttributes
    {
        #region Attributes

        // Private attributes
        private int id;
        private int step;
        private int nbColor;
        private string palette;
        private string gridColor;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets or sets the Step.
        /// </summary>
        public int Step
        {
            get { return step; }
            set { step = value; }
        }

        /// <summary>
        /// Gets or sets the NbColor.
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public int NbColor
        {
            get { return nbColor; }
            set { nbColor = value; }
        }

        /// <summary>
        /// Gets or sets the GridColor.
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public string GridColor
        {
            get { return gridColor; }
            set { gridColor = value; }
        }

        /// <summary>
        /// Gets or sets the ColorPalette.
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public string ColorPalette
        {
            get { return palette; }
            set { palette = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamAttributes"/> class.
        /// </summary>
        /// <param name="id">The Id value.</param>
        /// <param name="step">The Step value.</param>
        /// <param name="nbColor">The NbColor value.</param>
        /// <param name="gridColor">The GridColor value.</param>
        /// <param name="colorPalette">The ColorPalette value.</param>
        /// <authors>Mattis Galoppin</authors>
        public ParamAttributes(int id, int step, int nbColor, string gridColor, string colorPalette)
        {
            //initialization
            this.id = id;
            this.step = step;
            this.nbColor = nbColor;
            this.gridColor = gridColor;
            palette = colorPalette;
        }
        public void ToString()
        {
            Console.WriteLine(id);
            Console.WriteLine(step);
            Console.WriteLine(nbColor);
            Console.WriteLine(gridColor);
            Console.WriteLine(palette);
        }
        #endregion
    }
}
