using API.Data.BDD.TablesBDD.Img_Transformed;
using API.Data.BDD.TablesBDD.PARAMS;
using API.Data.BDD.TablesBDD.PDF;
using API.Data.initialize;
using Microsoft.EntityFrameworkCore;
using monapi.Data;
using System.Xml.Linq;

namespace TestDAO
{
    /// <summary>
    /// Tests the insertion data class
    /// </summary>
    public class InsertDATA
    {
        /// <summary>
        /// test insert in Params table
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Fact]
        public void InsertInParams()
        {
            initialise.DeleteAll();
            //insert data in params
            ParamsDAO pa = new ParamsDAO();
            string result = pa.InsertInParams(0, 0, "000000", "test");
            Assert.Equal("Success", result);

            //delete the row
            initialise.DeleteAll();
        }


        /// <summary>
        /// test insert in Image table 
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Fact]
        public void InsertInImg()
        {
            initialise.DeleteAll();
            //insert data in params before
            ParamsDAO pa = new ParamsDAO();
            pa.InsertInParams(0, 0, "000000", "test");

            //insert data in Img_Transformed
            Img_TransformedDAO img = new Img_TransformedDAO();
            string result = img.InsertInImg_Transformed("testNomImage", "test");

            Assert.Equal("Success", result);

            //delete the rows
            initialise.DeleteAll();

        }


        /// <summary>
        /// test insert in PDF table 
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        [Fact]
        public void InsertInPdf()
        {
            initialise.DeleteAll();
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

            initialise.DeleteAll();

        }
    }
}
