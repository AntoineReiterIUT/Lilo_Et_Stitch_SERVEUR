using Microsoft.EntityFrameworkCore;
using monapi.Data;
using monapi.Data.BDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDAO
{
    /// <summary>
    /// test get data class
    /// </summary>
    public class TestGetData
    { /*

        [Fact]
        public void TestGetDataImg()
        {
        
            //insertion data
            ParamsDAO pa = new ParamsDAO();
            pa.InsertInParams(0, 0, "000000", "test");

            Img_TransformedDAO img = new Img_TransformedDAO();
            img.InsertInImg_Transformed("testNomImage", "test");

            //we keep the image
            ImageAttributes result = img.GetImagesTransformed(0)[0];

            Assert.Equal(result.Name, "testNomImage");
            DeleteAll();
        }
        /// <summary>
        /// delete all tables
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public void DeleteAll()
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
        } */
    }
}
