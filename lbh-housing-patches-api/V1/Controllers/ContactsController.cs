using Microsoft.AspNetCore.Mvc;

namespace lbh_housingpatches_api.V1.Controllers
{
    [Route("api/v1/contacts")]
    [ApiController]
    [Produces("application/json")]
    public class ContactsController
    {
        [HttpGet]
        public JsonResult GetContacts()
        {
            return new JsonResult("") {StatusCode = 200};
        }
    }
}
