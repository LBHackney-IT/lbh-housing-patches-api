using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnitTests.V1.Helper
{
    public class DynamicsHelpers
    {
        public static JObject CreateContactJObject()
        {
            return new JObject
            {
                {"hackney_houseref", "FakeHouseRef"},
                {"hackney_uprn", "FakeUprn"},
                {"address1_composite", "FakeAddress"}
            };
        }
    }
}
