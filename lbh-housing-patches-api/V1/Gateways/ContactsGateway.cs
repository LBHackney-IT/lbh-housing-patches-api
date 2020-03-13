using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using lbh_housingpatches_api.V1.Boundary;
using lbh_housingpatches_api.V1.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace lbh_housingpatches_api.V1.Gateways
{
    public class ContactsGateway : IContactsGateway
    {
        private IXrmContext _xrmContext;
        private string      CrmUri = Environment.GetEnvironmentVariable("CRM_SVC_URI" + "/api/data/v8.2/contacts?");

        public ContactsGateway(IXrmContext xrmContext)
        {
            _xrmContext = xrmContext;
        }

        public async Task<string> GetContactForAttribute(RetrieveContactsRequest request)
        {
            var requestUri = new Uri($"{CrmUri}$select=hackney_houseref");
            var response   = _xrmContext.Client.GetStringAsync(requestUri);

            return await response;
        }

        public string GetAttributesForContactEntity()
        {
            var requestUri = new Uri($"{CrmUri}/api/data/v8.2/EntityDefinitions?$select=DisplayName,EntitySetName");
            var response   = _xrmContext.Client.GetStringAsync(requestUri);

            return response.Result;
        }
    }
}
