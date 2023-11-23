namespace API.Data.DAO_Patterns
{
    /// <summary>
    /// This interface will be used to structure the link between the API and the DAO_Patterns
    /// </summary>
    public interface IDAO_Patterns
    {


        /// <summary>
        /// Will check in the directory if a pattern with that name exists or not
        /// </summary>
        /// <param name="name">Name of the potentially new pattern</param>
        /// <returns>A boolean</returns>
        /// <author>Maxime LAFFAYE</author>
        public bool CheckIfPatternExist(string name);
    }
}
