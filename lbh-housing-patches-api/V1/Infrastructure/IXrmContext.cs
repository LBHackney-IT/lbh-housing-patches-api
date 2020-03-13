using System.Collections.Generic;
using System.Net.Http;
using lbh_housingpatches_api.V1.Gateways;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;

namespace lbh_housingpatches_api.V1.Infrastructure
{
    public interface IXrmContext
    {
        HttpClient Client { get; set; }
    }
}
