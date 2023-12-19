using monapi.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Data.BDD.TablesBDD
{
    public static class initialise
    {
        public static void DeleteAllInBdd()
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
