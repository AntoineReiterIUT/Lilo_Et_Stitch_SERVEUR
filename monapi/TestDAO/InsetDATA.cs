using API.Data.BDD;
using Microsoft.EntityFrameworkCore;
using monapi.Data;
using monapi.Data.BDD;
using System.Xml.Linq;

namespace TestDAO
{
    /// <summary>
    /// test insertion data class
    /// </summary>
    public class InsetDATA
    {
        /// <summary>
        /// test insert in Params table
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Fact]
        public void InsertInParams()
        {
            //insert data in params
            ParamsDAO pa = new ParamsDAO();
            string result = pa.InsertInParams(0, 0, "000000", "test");
            Assert.Equal("Success", result);

            //delete the row
            deleteDataParam();
        }

        /// <summary>
        /// delete the data test in Param
        /// </summary>
        /// <param name="tableName">the name of the table</param>
        ///<authors>Mattis Galoppin</authors>
        public void deleteDataParam()
        {
            using (var context = new MyContext())
            {
                //delete the row in Params with the PaletteDMC name = test
                FormattableString sql = $"DELETE FROM PARAMS WHERE PALETTEDMC = 'test';";
                context.Database.ExecuteSql(sql);
            }
        }
    }
}
