using API.Data.DAO_Patterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using monapi.Data;

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
        [HttpGet("sendParameters")]
        public ActionResult sendParameters(int? id, int? NB, int? color,string? name)
        {
            ActionResult result = BadRequest("No entry !");

            if (id.HasValue)
            {
                result = Ok();
                FakeDAO.Instance.AddStep(id.Value);
                FakeDAO.Instance.Addnb_color(NB.Value);
                FakeDAO.Instance.AddGrid_color(color.Value);
                FakeDAO.Instance.AddName(name);

            }
            return result;
        }

        [HttpPost("AddPDF")]
        public ActionResult<byte[]> AddPDF(byte[]? PDF)
        {
          ActionResult<byte[]> result = BadRequest("No entry !");
          result = Ok();
          FakeDAO.Instance.AddPDF(PDF);
          return result; ;
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
        /// <returns></returns>
        /// <author>Maxime LAFFAYE</author>

        [HttpGet("CheckIfExist")]
        public ActionResult<String> CheckIfExist(string name)
        {
            ActionResult<String> result = BadRequest("User already exists!");

            //Using the DAO to check if it exists or not
            if (!dAO_Patterns.CheckIfPatternExist(name)) result = Ok("User exists !");
            return result;
        }

        #endregion

    }
}