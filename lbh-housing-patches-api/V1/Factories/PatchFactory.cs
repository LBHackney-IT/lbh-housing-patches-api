using System.Collections.Generic;
using lbh_housingpatches_api.V1.Domain;
using Newtonsoft.Json.Linq;

namespace lbh_housingpatches_api.V1.Factories
{
    static public class PatchFactory
    {
        static public Patch FromJsonPatch(JObject response)
        {
            var addressList = new List<string>();
            var addresses = response["value"];

            foreach (var address in addresses)
            {
                addressList.Add(address["hackney_shortaddress"].ToString());
            }

            return new Patch { Addresses = addressList }; 

        }
    }
}