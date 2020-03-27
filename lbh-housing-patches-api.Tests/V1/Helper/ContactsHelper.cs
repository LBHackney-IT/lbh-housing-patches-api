using System;
using System.Net.Http;
using System.Net.Http.Headers;
using lbh_housingpatches_api.V1.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnitTests.V1.Helper
{
    public class DynamicsContextStub : IDynamicsContext
    {
        public JObject Contacts
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public JObject FetchContactsJSon(string houseRef, string personno)
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
