using System;
using lbh_housingpatches_api.V1.Boundary;
using lbh_housingpatches_api.V1.Gateways;

namespace lbh_housingpatches_api.V1.UseCase
{
    public class ListContacts : IListContacts
    {
        private readonly IContactsGateway _contactsGateway;
        public ListContacts(IContactsGateway contactsGateway)
        {
            _contactsGateway = contactsGateway;
        }

        public ContactsResponse Execute(ContactsRequest contactsRequest)
        {
            var results = _contactsGateway.GetContactsByReference(contactsRequest.Uprn);

            return new ContactsResponse(results, contactsRequest, DateTime.Now);
        }
    }
}