using System.Collections.Generic;
using System.Linq;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Factories;
using lbh_housingpatches_api.V1.Infrastructure;

namespace lbh_housingpatches_api.V1.Gateways
{
    public class ContactsGateway
    {
        private readonly IDynamicsContext _dynamicsContext;
        private readonly ContactFactory _contactFactory;

        public ContactsGateway(IDynamicsContext dynamicsContext)
        {
            _dynamicsContext = dynamicsContext;
            _contactFactory = new ContactFactory();
        }

        public IEnumerable<Contact> GetContactsByReference(string houseRef, string personno)
        {
            var jsonContacts = _dynamicsContext.FetchContactsJSon(houseRef, personno);
            List<Contact> contacts = _contactFactory.FromJsonContacts(jsonContacts);
            // var contact = new Contact
            // {
            //     HouseRef = jsonContacts["hackney_houseref"].ToString(),
            //     Uprn = jsonContacts["hackney_uprn"].ToString(),
            //     Address = jsonContacts["address1_composite"].ToString()
            // };

            return contacts;
            // return new List<Contact> {contact};
        }
    }
}
