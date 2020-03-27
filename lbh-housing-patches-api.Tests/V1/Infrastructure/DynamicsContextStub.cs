using System;
using lbh_housingpatches_api.V1.Infrastructure;
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

        public JObject FetchContactsJSon(string uprn)
        {
            return DynamicsHelpers.CreateContactJObject();
        }
    }
}
