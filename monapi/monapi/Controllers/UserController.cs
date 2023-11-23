using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using monapi.Data;

namespace monapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController() { }

        [HttpGet("AddStep")]
        public ActionResult<int> AddStep(int? id)
        {
            ActionResult<int> result = BadRequest("No entry !");

            if (id.HasValue)
            {
                result = Ok();
                FakeDAO.Instance.AddStep(id.Value);
                
            }
                return result;
        }

        [HttpGet("Addnb_color")]
            public ActionResult<int> Addnb_color(int? NB)
        {
            ActionResult<int> result = BadRequest("No entry !");

            if (NB.HasValue)
            {
                result = Ok();
                FakeDAO.Instance.AddStep(NB.Value);

            }
            return result; ;
        }


        [HttpGet("Addgrid_color")]
        public ActionResult<int> Addgrid_color(int? color)
        {
            ActionResult<int> result = BadRequest("No entry !");

            if (color.HasValue)
            {
                result = Ok();
                FakeDAO.Instance.AddStep(color.Value);

            }
            return result; ;
        }

        [HttpPost("AddPDF")]
        public ActionResult<byte[]> AddPDF(byte[]? PDF)
        {
          ActionResult<byte[]> result = BadRequest("No entry !");
          result = Ok();
          FakeDAO.Instance.AddPDF(PDF);
          return result; ;
        }



        /// <summary>
        /// Ajoute un utilisateur
        /// </summary>
        /// <param name="user">L'utilisateur à ajouter</param>
        /// <returns></returns>

    }
}