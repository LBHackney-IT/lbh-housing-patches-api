using System.Collections.Generic;
using System.Linq;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Factories;
using lbh_housingpatches_api.V1.Infrastructure;

namespace lbh_housingpatches_api.V1.Gateways
{
    public class ContactsGateway : IContactsGateway
    {
        private readonly IDynamicsContext _dynamicsContext;
        private readonly ContactFactory _contactFactory;

        public ContactsGateway(IDynamicsContext dynamicsContext)
        {
            _dynamicsContext = dynamicsContext;
            _contactFactory = new ContactFactory();
        }

            public List<Contact> GetContactsByReference(string uprn)
        {
            var jsonContacts = _dynamicsContext.FetchContactsJSon(uprn).Result;

            return _contactFactory.FromJsonContacts(jsonContacts);
        }
    }
}
