using System.Collections.Generic;
using lbh_housingpatches_api.V1.Domain;
using Newtonsoft.Json.Linq;

namespace lbh_housingpatches_api.V1.Factories
{
    public class ContactFactory
    {
        public List<Contact> FromJsonContacts(JObject jsonContacts)
        {
            var contact = new Contact
            {
                HouseRef = jsonContacts["hackney_houseref"].ToString(),
                Uprn = jsonContacts["hackney_uprn"].ToString(),
                Address = jsonContacts["address1_composite"].ToString()
            };
            return new List<Contact> {contact};
        }
    }
}
