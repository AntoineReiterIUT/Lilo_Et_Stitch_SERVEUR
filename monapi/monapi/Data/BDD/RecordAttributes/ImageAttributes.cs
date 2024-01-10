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
    /// <authors>Mattis GALOPPIN</authors>
    public class ImageAttributes
    {
        #region attributes

        private int id;
        private int id_params; //foreign key of params table
        private string name;
        private string path;
        private Byte[] bytes;

        #endregion


        #region properties

        /// <summary>
        /// Property : Gets or sets the identifier of the image.
        /// </summary>
        ///<authors>Mattis GALOPPIN</authors>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Property : Gets or sets the name of the image.
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Property : Gets or sets the path to the image.
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        /// <summary>
        /// Property : Gets or sets the identifier of the params.
        /// </summary>
        ///<authors>Mattis GALOPPIN</authors>
        public int ID_params
        {
            get { return id_params; }
            set { id_params = value; }
        }

        /// <summary>
        /// Property : Gets or sets the identifier of the params.
        /// </summary>
        /// <author>Maxime LAFFAYE</author>
        public byte[] Bytes
        {
            set { bytes = value; }
            get { return bytes; }
        }

        #endregion


        #region operations

        /// <summary>
        /// Initializes a new instance of the ImageAttributes class with the specified elements.
        /// </summary>
        /// <param name="id">The identifier of the imag.</param>
        /// <param name="name">The name of the image</param>
        /// <param name="path">The path to the image</param>
        /// <param name="idParams">The identifier for the settings</param>
        /// <authors>Mattis GALOPPIN</authors>
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
