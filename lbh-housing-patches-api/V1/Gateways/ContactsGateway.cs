using System.Collections.Generic;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Infrastructure;

namespace lbh_housingpatches_api.V1.Gateways
{
    public class ContactsGateway
    {
        private readonly IDynamicsContext _dynamicsContext;

        public ContactsGateway(IDynamicsContext dynamicsContext)
        {
            _dynamicsContext = dynamicsContext;
        }

        public IEnumerable<Contact> GetContactsByReference(string houseRef, string personno)
        {
            var jsonContact = _dynamicsContext.FetchContactsJSon(houseRef, personno);
            var contact = new Contact 
            { 
                HouseRef = jsonContact["hackney_houseref"].ToString(), 
                Uprn = jsonContact["hackney_uprn"].ToString(),
                Address = jsonContact["address1_composite"].ToString()

            };

            return new List<Contact>{ contact };
        }
    }
}