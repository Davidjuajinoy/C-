using System.Configuration;
using System.Web.Http;

namespace TheCodeCamp.Controllers
{
    public class OperationsController : ApiController
    {
        [HttpOptions]
        [Route("api/refreshconfig")]
        // se consume por medio de la opcion option en postman.
        public IHttpActionResult RefreshAppSettings()
        {
            try
            {
                ConfigurationManager.RefreshSection("AppSettings");
                return Ok();
            }
            catch (System.Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}