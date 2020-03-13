using System;
using System.Collections.Generic;
using lbh_housingpatches_api.V1.UseCase;
using lbh_housingpatches_api.V1.Boundary;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Gateways;

namespace lbh_housingpatches_api.V1.UseCase
{
    public class RetrieveContactsUseCase : IRetrievingContacts
    {
        private readonly IContactsGateway _contactsGateway;

        public RetrieveContactsUseCase(IContactsGateway contactsGateway)
        {
            _contactsGateway = contactsGateway;
        }

        public RetrieveContactsResponse Execute(RetrieveContactsRequest request)
        {
            List<Contact> results = null;
            var           task    = _contactsGateway.GetContactForAttribute(request);
            Console.WriteLine("In the Use Case");
            Console.WriteLine(task.Result);

            // return new RetrieveContactsResponse(results, request, DateTime.Now);
            return new RetrieveContactsResponse(results, request, DateTime.Now);
        }
    }
}
