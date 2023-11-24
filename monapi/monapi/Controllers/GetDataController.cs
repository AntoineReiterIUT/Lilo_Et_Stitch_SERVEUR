using Microsoft.AspNetCore.Mvc;
using API.Data.BDD;
using API.Data.DAO_Patterns;
using Microsoft.AspNetCore.Mvc.Formatters;
using monapi.Data;
using monapi.Data.BDD;
using System.Drawing;
using System.Xml.Linq;


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

                //Transforming into a json
                result = new JsonResult(new { success = true, message = "Success!", data = images });
            }
            return result;
        }

    }
}
