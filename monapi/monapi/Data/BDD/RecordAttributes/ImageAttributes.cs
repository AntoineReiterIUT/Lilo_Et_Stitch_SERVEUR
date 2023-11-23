using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monapi.Data.BDD
{
    /// <summary>
    /// Represents the attributes of an image.
    /// </summary>
    /// <authors>Mattis Galoppin</authors>
    public class ImageAttributes
    {
        #region Attributes
        private int id;
        private int id_params; //foreign key of params table
        private string name;
        private string path;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the image.
        /// </summary>
        ///<authors>Mattis Galoppin</authors>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets or sets the name of the image.
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the path to the image.
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        /// <summary>
        /// Gets or sets the identifier of the params.
        /// </summary>
        ///<authors>Mattis Galoppin</authors>
        public int ID_params
        {
            get { return id_params; }
            set { id_params = value; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageAttributes"/> class with the specified elements.
        /// </summary>
        /// <param name="id">The identifier of the image.</param>
        /// <param name="name">The name of the image.</param>
        /// <param name="path">The path to the image.</param>
        /// <authors>Mattis Galoppin</authors>
        public ImageAttributes(int id, string name, string path, int idParams)
        {
            //initialization
            this.id = id;
            this.name = name;
            this.path = path;
            id_params = idParams;

        }

        #endregion
    }
}
