using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using lbh_housingpatches_api.V1.Boundary;

namespace lbh_housingpatches_api.V1.Gateways
{
    public interface IContactsGateway
    {
        Task<string> GetContactForAttribute(RetrieveContactsRequest request);
        string       GetAttributesForContactEntity();
    }
}
