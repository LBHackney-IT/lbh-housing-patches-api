using System.Collections.Generic;
using lbh_housingpatches_api.V1.Domain;
using Newtonsoft.Json.Linq;

namespace lbh_housingpatches_api.V1.Factories
{
    public class ContactFactory
    {
        public List<Contact> FromJsonContacts(JObject response)
        {
            var contacts = response["value"][0];
            var contact = new Contact
            {
                HouseRef = contacts["hackney_houseref"].ToString(),
                Uprn = contacts["hackney_uprn"].ToString(),
                Address = contacts["address1_composite"].ToString()
            };
            return new List<Contact> {contact};
        }
    }
}
