using System;
using System.Collections.Generic;
using System.Linq;
using lbh_housingpatches_api.V1.Boundary;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Factories;
using lbh_housingpatches_api.V1.Gateways;
using lbh_housingpatches_api.V1.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace lbh_housingpatches_api.V1.Controllers
{
    [Route("api/v1/contacts")]
    [ApiController]
    [Produces("application/json")]
    public class ContactsController
    {
        private ContactsGateway _contactsGateway;

        public ContactsController()
        {
            _contactsGateway = new ContactsGateway(new DynamicsContext());
        }

        [HttpGet]
        public JsonResult GetContacts(ContactsRequest request)
        {
            var contacts = _contactsGateway.GetContactsByReference(request.Uprn);

            var result = new ContactsResponse(contacts, new ContactsRequest(), DateTime.Now);

            var jsonResult = new JsonResult(result) {StatusCode = 200};
            return jsonResult;
        }
    }
}
