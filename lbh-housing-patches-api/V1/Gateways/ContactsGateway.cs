using System.Collections.Generic;
using lbh_housingpatches_api.V1.Domain;

namespace lbh_housingpatches_api.V1.Gateways
{
    public class ContactsGateway
    {
        public IEnumerable<Contact> GetContactsByReference(string housingref, string personno)
        {
            var contact = new Contact{
                HousingRef = housingref
            };
            return new List<Contact>{contact};
        }
    }
}