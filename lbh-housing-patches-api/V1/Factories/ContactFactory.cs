using System;
using System.Collections.Generic;
using System.Linq;
using lbh_housingpatches_api.V1.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lbh_housingpatches_api.V1.Factories
{
    public class ContactFactory
    {
        public List<Contact> FromJsonContacts(JObject response)
        {
            var contactsList = new List<Contact>();
            var contacts = response["value"];

            foreach (var contact in contacts)
            {
                contactsList.Add(
                    new Contact
                    {
                        HouseRef = contact["hackney_houseref"].ToString(),
                        Uprn = contact["hackney_uprn"].ToString(),
                        Address = contact["address1_composite"].ToString()
                    }
                );
            }

            return contactsList;
        }
    }
}
