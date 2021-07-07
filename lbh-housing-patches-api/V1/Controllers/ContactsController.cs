using System;
using System.Collections.Generic;
using System.Linq;
using lbh_housingpatches_api.V1.Boundary;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Factories;
using lbh_housingpatches_api.V1.Gateways;
using lbh_housingpatches_api.V1.Infrastructure;
using lbh_housingpatches_api.V1.UseCase;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace lbh_housingpatches_api.V1.Controllers
{
    [Route("api/v1/contacts")]
    [ApiController]
    [Produces("application/json")]
    public class ContactsController
    {
        private IListContacts _listContacts;

        public ContactsController(IListContacts listContacts)
        {
            _listContacts = listContacts;
        }

        [HttpGet]
        public JsonResult GetContacts([FromBody] ContactsRequest request)
        {
            if (request.Uprn == null) throw new ArgumentNullException("Uprn is required.");

            var useCaseResponse = _listContacts.Execute(request);
            var jsonResult = new JsonResult(useCaseResponse) {StatusCode = 200};
            return jsonResult;
        }
    }
}
