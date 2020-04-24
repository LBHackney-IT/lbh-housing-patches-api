using System.Collections.Generic;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Infrastructure;

namespace lbh_housingpatches_api.V1.Gateways
{
    public class PatchesGateway : IPatchesGateway
    {
        private readonly IDynamicsContext _dynamicsContext;

        public PatchesGateway(IDynamicsContext dynamicsContext)
        {
            _dynamicsContext = dynamicsContext;
        }
        Patch IPatchesGateway.GetPatchByGuid(string guid)
        {
            var addressList = new List<string>();
            var patchJson = _dynamicsContext.FetchPatchJson(guid).Result;
            var addresses = patchJson["value"];

            foreach (var address in addresses)
            {
                addressList.Add(address["hackney_shortaddress"].ToString());
            }

            return new Patch { Addresses = addressList }; 
        }
    }
}