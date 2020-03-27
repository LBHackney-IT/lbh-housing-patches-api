using Newtonsoft.Json.Linq;

namespace lbh_housingpatches_api.V1.Infrastructure
{
    public interface IDynamicsContext
    {
        JObject FetchContactsJSon(string uprn);
    }
}
