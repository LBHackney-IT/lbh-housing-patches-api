using lbh_housingpatches_api.V1.UseCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace lbh_housingpatches_api.Controllers.V1
{
    public class AttributesController : BaseController
    {
        private IRetrievingAttributes         _retrieveAttributes;
        private ILogger<AttributesController> _logger;

        public AttributesController(IRetrievingAttributes retrieveAttributes, ILogger<AttributesController> logger)
        {
            _retrieveAttributes = retrieveAttributes;
            _logger             = logger;
        }

        [HttpGet, Route("api/v1/attributes")]
        public JsonResult GetAttributes()
        {
            var usecaseResponse = _retrieveAttributes.Execute();
            _logger.LogInformation("Fetching all attributes on Dynamics 365");
            return new JsonResult(JsonConvert.DeserializeObject(usecaseResponse)) {StatusCode = 200};
        }
    }
}
