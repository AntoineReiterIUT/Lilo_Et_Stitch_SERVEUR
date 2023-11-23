using monapi.Data.BDD;
using monapi.Data;

namespace API.Data.BDD
{/// <summary>
/// interface Params DAO, for inset and get  params values
/// </summary>
    public interface IParamsDAO
    {
        #region Methods
        /// <summary>
        /// Inserts data into the Params table
        /// </summary>
        /// <param name="step">Step of the image</param>
        /// <param name="nbColor">Number of colors used</param>
        /// <param name="gridColor">Color of the grid</param>
        /// <param name="csv">Palette DMC</param>
        /// <returns>Success or failure message</returns>
        /// <authors>Mattis Galoppin</authors>
        public string InsertInParams(int step, int nbColor, string gridColor, string csv);
        /// <summary>
        /// Returns the parameters of an image with its ID
        /// </summary>
        /// <param name="id">ID of the image</param>
        /// <returns>Parameter attributes</returns>
        /// <author>Mattis Galoppin</author>
        public ParamAttributes GetParamsByIdParam(int id);
        #endregion
    }
}
