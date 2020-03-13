using System;
using lbh_housingpatches_api.V1.Boundary;
using lbh_housingpatches_api.V1.UseCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lbh_housingpatches_api.Controllers.V1
{
    public class ContactsController : BaseController
    {
        private IRetrievingContacts         _retrieveContacts;
        private ILogger<ContactsController> _logger;

        public ContactsController(IRetrievingContacts retrieveContacts, ILogger<ContactsController> logger)
        {
            _retrieveContacts = retrieveContacts;
            _logger           = logger;
        }

        [HttpGet, Route("api/v1/contacts")]
        // public JsonResult GetCustomers([FromQuery] RetrieveCustomersRequest request) //TODO:
        public JsonResult GetContacts()
        {
            var usecaseResponse = _retrieveContacts.Execute(new RetrieveContactsRequest());
            _logger.LogWarning(usecaseResponse.ToString());
            Console.WriteLine("In the Controller");
            return new JsonResult(usecaseResponse) {StatusCode = 200};
        }
    }
}
