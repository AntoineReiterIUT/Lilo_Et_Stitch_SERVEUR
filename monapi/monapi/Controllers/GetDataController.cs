using Microsoft.AspNetCore.Mvc;
using API.Data.BDD;
using API.Data.DAO_Patterns;
using Microsoft.AspNetCore.Mvc.Formatters;
using monapi.Data;
using monapi.Data.BDD;
using System.Drawing;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Controllers
{

    /// <summary>
    /// This class will be the endpoint handler
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GetDataController : ControllerBase
    {
        #region attributes
        private IDAO_Patterns dAO_Patterns = new DAO_Patterns();
        private IParamsDAO paramsDAO = new ParamsDAO();
        private IImg_TransformedDAO imageTransformedBDD = new Img_TransformedDAO();
        private IPdfDAO pdfDao = new PdfDAO();
        #endregion


        /// <summary>
        /// This endpoint will return a list of images, using the given page number
        /// </summary>
        /// <param name="page"></param>
        /// <returns>List of images, as a json file</returns>
        /// <author>Maxime LAFFAYE</author>
        [HttpGet("GetImages")]
        public ActionResult GetImages(int ?page)
        {
            ActionResult result = BadRequest("No entry !");

            if (page != null)
            {
                //Getting the images from the bdd
                List<ImageAttributes> images = imageTransformedBDD.GetImagesTransformed((int)page);

                //Adding the image as an array of bytes
                foreach(ImageAttributes image in images)
                {
                    image.Bytes = dAO_Patterns.GetFile(image.Name, "png");
                }

                //Transforming into a json
                result = new JsonResult(images);
            }
            return result;
        }


        /// <summary>
        /// This endpoint will return the settings
        /// </summary>
        /// <param name="Id">Id of the settings</param>
        /// <returns>settings in a json</returns>
        /// <author>Maxime LAFFAYE</author>
        [HttpGet("GetSettings")]
        public ActionResult GetSettings(int? Id)
        {
            ActionResult result = BadRequest("No entry !");

            if (Id != null)
            {
                //Getting the settings from the bdd
                ParamAttributes settings = paramsDAO.GetParamsByIdParam((int)Id);

                //Transforming into a json
                result = new JsonResult(settings);
            }
            return result;
        }


        /// <summary>
        /// This endpoint will return the PDF, using the Name of the project
        /// </summary>
        /// <param name="name"> the name of the project </param>
        /// <returns> the byte array on Json of the PDF </returns>
        [HttpGet("GetPDF")]
        public ActionResult GetPDF(string? name)
        {
            ActionResult result = BadRequest("No entry !");
            if (name != null)
            {
                byte[] test= dAO_Patterns.GetFile(name, "pdf");
                result = new JsonResult(test);
            }
            return result;
        }
        /// <summary>
        /// This endpoint will return the 6 images with the same name as the researched one
        /// </summary>
        /// <param name="name"> name of search </param>
        /// <param name="page"> the page number </param>
        /// <returns> return bad request if name is null if not, return the Json of 6 ImageAttributes</returns>
        /// <author>Antoine REITER</author>
        [HttpGet("GetImgBySearch")]
        public ActionResult GetImgBySearch(string ?name , int page)
        {
            try
            {
                List<ImageAttributes> ListeSchearch = new List<ImageAttributes>();

                ActionResult result = BadRequest("No entry !");
                Img_TransformedDAO x = new Img_TransformedDAO();
                //Getting the images from the bdd

                if (name == null) //if the name is null
                    name = "";

                ListeSchearch = x.GetImagesBySearch(name, page);

                //Adding the image as an array of bytes
                foreach (ImageAttributes image in ListeSchearch)
                {
                    image.Bytes = dAO_Patterns.GetFile(image.Name, "png");
                }
                result = new JsonResult(ListeSchearch);

                //Transforming into a json

                return result;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// This endpoint will return the number of pages
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        /// <authors>Antoine Reiter & Mattis Galoppin</authors>
        [HttpGet("GetNumberPage")]
        public ActionResult GetNumberPage(string ?word)
        {
            
            ActionResult result = BadRequest("No entry !");
            Img_TransformedDAO x = new Img_TransformedDAO();

            if (word == null)
                word = "";
            result = new JsonResult(x.GetNumberPage(word)); //get number of pages
          
            
            return result;
        }
    }
}

