using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace lbh_housingpatches_api.V1.Infrastructure
{
    public interface IDynamicsContext
    {
        Task<JObject> FetchContactsJSon(string uprn);
        Task<JObject> FetchPatchJson(string guid);
    }
}
