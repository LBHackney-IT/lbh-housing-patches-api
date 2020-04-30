using System.Collections.Generic;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Factories;
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
            var patchJson = _dynamicsContext.FetchPatchJson(guid).Result;
            return PatchFactory.FromJsonPatch(patchJson);
        }
    }
}