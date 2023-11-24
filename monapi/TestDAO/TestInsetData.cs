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
        /// test insert in Image table 
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Fact]
        public void InsertInImg()
        {
            //insert data in params before
            ParamsDAO pa = new ParamsDAO();
            pa.InsertInParams(0, 0, "000000", "test");

            //insert data in Img_Transformed
            Img_TransformedDAO img = new Img_TransformedDAO();
            string result = img.InsertInImg_Transformed("testNomImage", "test");

            Assert.Equal("Success", result);

            //delete the rows
            deleteDataImg();
            deleteDataParam();

        }
        /// <summary>
        /// test insert in PDF table 
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        [Fact]
        public void InsertInPdf()
        {
            //insert data in params before
            ParamsDAO pa = new ParamsDAO();
            pa.InsertInParams(0, 0, "000000", "test");

            //insert data in Img_Transformed
            Img_TransformedDAO img = new Img_TransformedDAO();
            img.InsertInImg_Transformed("testNomImage", "test");

            //insert data in Pdf
            PdfDAO pdf = new PdfDAO();
            string result = pdf.InsertInPdf("testPDF");
            Assert.Equal("Success", result);

            //delete the rows
            deleteDataPdf();
            deleteDataImg();
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
        /// <summary>
        /// delete the data test in Img_Transformed
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public void deleteDataImg()
        {
            using (var context = new MyContext())
            {
                //delete the row in Params with the image name = testNomImage
                FormattableString sql = $"DELETE FROM IMG_TRANSFORMED WHERE IMG = 'testNomImage';";
                context.Database.ExecuteSql(sql);
            }
        }
                /// <summary>
        /// delete the data test in PDF
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public void deleteDataPdf()
        {
            using (var context = new MyContext())
            {
                //delete the row in Params with the image name = testNomImage
                FormattableString sql = $"DELETE FROM PDF WHERE THE_PDF = 'testPDF';";
                context.Database.ExecuteSql(sql);
            }
        }
    }
}
