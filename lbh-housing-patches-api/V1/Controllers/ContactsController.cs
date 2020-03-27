using System;
using System.Collections.Generic;
using System.Linq;
using lbh_housingpatches_api.V1.Boundary;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Factories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
            var contactJson = new JObject
            {
                {"hackney_houseref", "House Ref"},
                {"hackney_uprn", "UPRN"},
                {"address1_composite", "Composite Address"}
            };

            var factory = new ContactFactory();
            var firstJsonContact = factory.FromJsonContacts(contactJson).First();
            var contacts = new List<Contact>{firstJsonContact};

            var result = new ContactsResponse(contacts, new ContactsRequest(), DateTime.Now);

            var jsonResult = new JsonResult(result) {StatusCode = 200};
            return jsonResult;
        }
    }
}
