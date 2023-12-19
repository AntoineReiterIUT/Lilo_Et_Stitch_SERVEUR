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
    { 
        /// <summary>
        /// test to getImagesTransformed 
        /// </summary>
        [Fact]
        public void TestGetDataImg()
        {
            //wait 7 seconds before delete all
            wait7s().Wait();
            DeleteAll();
            //insertion data
            ParamsDAO pa = new ParamsDAO();
            pa.InsertInParams(0, 0, "000000", "test");
            pa.InsertInParams(0, 0, "000000", "test2");
            Img_TransformedDAO img = new Img_TransformedDAO();

            img.InsertInImg_Transformed("FakePath", "testNomImage");
            img.InsertInImg_Transformed("secondFakePath", "testNomImage2");
            
            //we keep the images
            ImageAttributes result = img.GetImagesTransformed(0)[0];
            ImageAttributes result2 = img.GetImagesTransformed(0)[1];

            //check the names
            Assert.Equal("testNomImage",result.Name);
            Assert.Equal("testNomImage2", result2.Name);


           // DeleteAll();
        }
        /// <summary>
        /// Test get param by id
        /// </summary>
        [Fact]
        public void TestGetDataParam()
        {
            //wait 7 seconds before delete all
            wait7s().Wait();
            DeleteAll();
            //insertion data
            ParamsDAO pa = new ParamsDAO();
            pa.InsertInParams(0, 0, "000000", "testPalette");


            //insert data in Img_Transformed
            Img_TransformedDAO img = new Img_TransformedDAO();
            img.InsertInImg_Transformed("testNomImage", "test");

            ImageAttributes result = img.GetImagesTransformed(0)[0];

            ParamAttributes res = pa.GetParamsByIdParam(result.ID_params);
            Assert.Equal(res.ColorPalette,"testPalette");
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
        }
        /// <summary>
        /// wait 7 seconds
        /// </summary>
        public async Task wait7s()
        {
            await Task.Delay(7000);
        }
    }
}
