using API.Data.DAO_Patterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using monapi.Data;
using System.Drawing;

namespace monapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        #region attributes
        private IDAO_Patterns dAO_Patterns = new DAO_Patterns();
        #endregion

        #region _________ operations _________
        public UserController() { }


        /// <summary>
        /// This endpoint will receive the parameters
        /// </summary>
        /// <param name="name">Name of the pattern</param>
        /// <param name="step">Step of the cases</param>
        /// <param name="maxColors">Max amount of colors</param>
        /// <param name="gridColor">Color of the grid</param>
        /// <returns>Result of the request</returns>
        /// <author>Antoine REITER - Maxime LAFFAYE</author>
        [HttpGet("SendParameters")]
        public ActionResult SendParameters(string ?name, int ?step, int ?maxColors, string ?gridColor)
        {
            ActionResult result = BadRequest("No entry !");

            if(name != null && step != null && maxColors != null && gridColor != null)
            {
                //Creating the directory
                Console.WriteLine(dAO_Patterns.CheckIfPatternExist(name));
                dAO_Patterns.CreatePattern(name);
                Console.WriteLine(dAO_Patterns.CheckIfPatternExist(name));
                result = Ok("Success!");
            }
            return result;
        }


        /// <summary>
        /// This endpoint will add the pdf to the directory
        /// </summary>
        /// <param name="PDF">The PDF, as an array of bytes</param>
        /// <param name="name">Name of the pattern (directory) in which it should be added to</param>
        /// <returns>Result of the request</returns>
        /// <author>Maxime LAFFAYE</author>
        [HttpPost("AddPDF")]
        public ActionResult<byte[]> AddPDF(byte[]? PDF,string name)
        {
            ActionResult<byte[]> result = BadRequest("No entry !");

            //If it exists, we can use the DAO to add the PDF
            if(PDF != null)
            {
                dAO_Patterns.AddPDF(PDF,name);
                result = Ok("Success!");
            }

          return result;
        }

        [HttpPost("AddCSV")]
        public ActionResult<byte[]> AddCSV(byte[]? CSV)
        {
            ActionResult<byte[]> result = BadRequest("No entry !");
            result = Ok();
            FakeDAO.Instance.AddCSV(CSV);
            return result; ;
        }

        [HttpPost("AddIMG")]
        public ActionResult<byte[]> AddIMG(byte[]? IMG)
        {
            ActionResult<byte[]> result = BadRequest("No entry !");
            result = Ok();
            FakeDAO.Instance.AddIMG(IMG);
            return result; ;
        }
        /// <summary>
        /// Endpoint to check if the pattern doesn't exist already
        /// </summary>
        /// <param name="name"></param>
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

        #endregion

    }
}