using monapi.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Data.initialize
{
    /// <summary>
    /// initialize the BDD
    /// </summary>
    public static class initialise
    {

        /// <summary>
        /// delete all tables
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public static void DeleteAll()
        {
            using (var context = new MyContext())
            {
                //delete PDF table
                FormattableString sql = $"DELETE FROM PDF;";
                context.Database.ExecuteSql(sql);

                //delete img table
                sql = $"DELETE FROM IMG_TRANSFORMED;";
                context.Database.ExecuteSql(sql);

                //delete Params table Params
                sql = $"DELETE FROM PARAMS;";
                context.Database.ExecuteSql(sql);
            }
        }
    }
}
