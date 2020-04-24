using System.Collections.Generic;
using lbh_housingpatches_api.V1.Domain;

namespace lbh_housingpatches_api.V1.Gateways
{
    public class PatchesGateway : IPatchesGateway
    {
        Patch IPatchesGateway.GetPatchByGuid(string guid)
        {
            return new Patch();
        }
    }
}