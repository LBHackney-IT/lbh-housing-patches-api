
using lbh_housingpatches_api.V1.Domain;
using Newtonsoft.Json.Linq;

namespace lbh_housingpatches_api.V1.Factories
{
    public class ContactFactory
    {
        public Contact FromJsonObject(JObject jsonResponse)
        {
            return new Contact();
        }
    }
}