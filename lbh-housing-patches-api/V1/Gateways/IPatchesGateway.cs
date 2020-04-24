using System.Collections.Generic;
using lbh_housingpatches_api.V1.Domain;

namespace lbh_housingpatches_api.V1.Gateways
{
    public interface IPatchesGateway
    {
        Patch GetPatchByGuid(string guid);
    }
}