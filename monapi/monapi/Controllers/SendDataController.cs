using API.Data.BDD.TablesBDD.Img_Transformed;
using API.Data.BDD.TablesBDD.PARAMS;
using API.Data.BDD.TablesBDD.PDF;
using API.Data.DAO_Patterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using monapi.Data;
using monapi.Data.BDD;
using System.Drawing;

namespace monapi.Controllers
{
    /// <summary>
    /// This class contains the methods/endpoints that will be called whenever a client needs to send data to the API.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SendDataController : ControllerBase
    {
        #region attributes

        private IDAO_Patterns dAO_Patterns = new DAO_Patterns();
        private IParamsDAO paramsDAO = new ParamsDAO();
        private IImg_TransformedDAO imageTransformedBDD = new Img_TransformedDAO();
        private IPdfDAO pdfDao = new PdfDAO();

        #endregion


        #region  operations 

        public SendDataController() { }


        /// <summary>
        /// This endpoint will receive the parameters
        /// </summary>
        /// <param name="name">Name of the pattern</param>
        /// <param name="step">Step of the cases</param>
        /// <param name="colors">amount of colors</param>
        /// <param name="gridColor">Color of the grid</param>
        /// <returns>Result of the request</returns>
        /// <author>Antoine REITER - Maxime LAFFAYE</author>
        [HttpGet("SendParameters")]
        public ActionResult ReceiveParameters(string? name, int? step, int? maxColors, string? gridColor)
        {
            ActionResult result = BadRequest("No entry !");

            if (name != null && step != null && maxColors != null && gridColor != null)
            {
                //Creating the directory
                dAO_Patterns.CreatePattern(name);
                
                //Inserting into the BDD
                string successBDD = paramsDAO.InsertInParams((int)step, (int)maxColors, gridColor, string.Format($"{name}_CSV.csv"));
                successBDD += imageTransformedBDD.InsertInImg_Transformed(string.Format($"{name}_IMG.png"), name);
                successBDD += pdfDao.InsertInPdf(string.Format($"{name}_PDF.pdf"));

                //Checking if it succeeded to return success or not
                if (successBDD == "SuccessSuccessSuccess") result = Ok("Success!");
            }
            return result;
        }


        /// <summary>
        /// This endpoint will add the pdf to the directory
        /// </summary>
        /// <param name="PDF">The PDF, as an array of bytes</param>
        /// <param name="name">Name of the pattern repertory in which it should be added to</param>
        /// <returns>Result of the request</returns>
        /// <author>Maxime LAFFAYE</author>
        [HttpPost("AddPDF")]
        public ActionResult AddPDF([FromBody] byte[] PDF, [FromQuery] string name)
        {
            ActionResult result = BadRequest("No entry !");

            //If it exists, we can use the DAO to add the PDF
            if(PDF != null)
            {
                //Adding the PDF to the directory
                dAO_Patterns.AddFile(PDF,name,"pdf");
                result = Ok("Success!");
            }

          return result;
        }


        /// <summary>
        /// This endpoint will add the palette to the directory
        /// </summary>
        /// <param name="CSV">The Palette, as an array of bytes</param>
        /// <param name="name">Name of the pattern repository in which it should be added to</param>
        /// <returns>Result of the request</returns>
        /// <author>Maxime LAFFAYE</author>
        [HttpPost("AddCSV")]
        public ActionResult AddCSV([FromBody] byte[] CSV, [FromQuery] string name)
        {
            ActionResult result = BadRequest("No entry !");

            //If it exists, we can use the DAO to add the Palette
            if (CSV != null)
            {
                //Adding the Palette to the directory
                dAO_Patterns.AddFile(CSV, name, "csv");
                result = Ok("Success!");
            }

            return result;
        }

        /// <summary>
        /// Endpoint to add the image to the directory
        /// </summary>
        /// <param name="IMG">The image, as an array of bytes</param>
        /// <param name="name">Name of the pattern repertory in which it should be added to</param>
        /// <returns>Result of the request</returns>
        [HttpPost("AddIMG")]
        /// <author>Maxime LAFFAYE</author>
        public ActionResult AddIMG([FromBody] byte[] IMG, [FromQuery] string name)
        {
            ActionResult result = BadRequest("No entry !");

            //If it exists, we can use the DAO to add the image
            if (IMG != null)
            {
                //Adding the image to the directory
                dAO_Patterns.AddFile(IMG, name, "png");
                result = Ok("Success!");
            }

            return result;
        }


        /// <summary>
        /// Endpoint to check if the pattern doesn't exist already
        /// </summary>
        /// <param name="name">Name of the pattern to check</param>
        /// <returns>Result of the request</returns>
        /// <author>Maxime LAFFAYE</author>

        [HttpGet("CheckIfExist")]
        public ActionResult<String> CheckIfExist(string name)
        {
            Console.WriteLine(name);
            ActionResult<String> result = BadRequest("Pattern already exists !");

            //Using the DAO to check if it exists or not
            if (!dAO_Patterns.CheckIfPatternExist(name)) result = Ok("Pattern doesn't exist !");
            return result;
        }


        /// <summary>
        /// This endpoint will call the methods to delete a pattern from its name
        /// </summary>
        /// <param name="name">Name of the pattern to delete</param>
        /// <returns>
        /// <author>Antoine REITER</author>
        [HttpGet("deleteOnePatterns")]
        public ActionResult clearOnePatterns(string name)
        {
            //Calling the method to delete the pattern
            bool condition = dAO_Patterns.DeletePattern(name);
            return condition ? (ActionResult)Ok("Pattern deleted") : BadRequest("Couldn't delete the pattern");
        }


        /// <summary>
        /// This endpoint, will call the method to delete all patterns saved
        /// </summary>
        /// <author>Antoine REITER</author>
        [HttpGet("DeleteAll")]
        public ActionResult clearAll()
        {
            //Calling the method to delete all patterns
            dAO_Patterns.DeleteAllPatterns();
            return new OkResult();
        }

        #endregion

    }
}