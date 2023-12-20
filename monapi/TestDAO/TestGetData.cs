using API.Data.BDD;
using API.Data.initialize;
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
        /// <authors>Mattis Galoppin</authors>
        [Fact]
        public void TestGetDataImg()
        {
            //wait 7 seconds before delete all
            wait7s().Wait();
            initialise.DeleteAll();
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


           initialise.DeleteAll();
        }
        /// <summary>
        /// Test get param by id
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Fact]
        public void TestGetDataParam()
        {
            //wait 7 seconds before delete all
            wait7s().Wait();
            initialise.DeleteAll();
            //insertion data
            ParamsDAO pa = new ParamsDAO();
            pa.InsertInParams(0, 0, "000000", "testPalette");


            //insert data in Img_Transformed
            Img_TransformedDAO img = new Img_TransformedDAO();
            img.InsertInImg_Transformed("testNomImage", "test");

            ImageAttributes result = img.GetImagesTransformed(0)[0];

            ParamAttributes res = pa.GetParamsByIdParam(result.ID_params);
            Assert.Equal(res.ColorPalette,"testPalette");
            initialise.DeleteAll();
        }
        /// <summary>
        /// Test the GetPdfById in the BDD
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Fact]
        public void TestGetDataPdf()
        {
            initialise.DeleteAll();
            //insertion data
            ParamsDAO pa = new ParamsDAO();
            pa.InsertInParams(0, 0, "000000", "testPalette");

            //insert data in Img_Transformed
            Img_TransformedDAO img = new Img_TransformedDAO();
            img.InsertInImg_Transformed("testNomImage", "test");

           
            IPdfDAO pdf = new PdfDAO();
            pdf.InsertInPdf("fakePath");

            ImageAttributes imageAttributes = img.GetImagesTransformed(0)[0];
            string result =  pdf.GetPdfByIdImg(imageAttributes.ID);
            Assert.Equal("fakePath", result);
            initialise.DeleteAll();

        }
        /// <summary>
        /// test GetImagesBySearch
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Fact]
        public void TestGetDataBySearch()
        {
            initialise.DeleteAll();
            //insertion data
            ParamsDAO pa = new ParamsDAO();
            pa.InsertInParams(0, 0, "000000", "testPalette");

            //insert data in Img_Transformed
            Img_TransformedDAO img = new Img_TransformedDAO();
            img.InsertInImg_Transformed("fakePath", "test");
            List<ImageAttributes> imageAttributes = img.GetImagesBySearch("te",0);

            Assert.Equal("test", imageAttributes[0].Name);
            Assert.Equal("fakePath", imageAttributes[0].Path);
            initialise.DeleteAll();
        }
        /// <summary>
        /// Test the GetNumberPages
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Fact]
        public void TestGetDataPages()
        {
            initialise.DeleteAll();
            ParamsDAO pa = new ParamsDAO();
            pa.InsertInParams(0, 0, "000000", "testPalette");

            Img_TransformedDAO img = new Img_TransformedDAO();
            img.InsertInImg_Transformed("fakePath", "test");
            //test number pages
            Assert.Equal(1, img.GetNumberPage(""));

            img.InsertInImg_Transformed("fakePath3", "test3");
            //test with search
            Assert.Equal(1, img.GetNumberPage("test3"));
            Assert.Equal(0, img.GetNumberPage("z"));
            initialise.DeleteAll();
        }
        /// <summary>
        /// wait 7 seconds
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public async Task wait7s()
        {
            await Task.Delay(7000);
        }
    }
}
