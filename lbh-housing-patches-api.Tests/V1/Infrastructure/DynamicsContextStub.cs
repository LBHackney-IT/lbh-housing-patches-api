using System;
using System.Threading.Tasks;
using lbh_housingpatches_api.V1.Infrastructure;
using Newtonsoft.Json.Linq;

namespace UnitTests.V1.Helper
{
    public class DynamicsContextStub : IDynamicsContext
    {
        Task<JObject> IDynamicsContext.FetchContactsJSon(string uprn)
        {
            var payloadContent = new JArray();
            var contactObject = new JObject(){
                {"hackney_houseref", "8888888"},
                {"hackney_uprn", uprn},
                {"address1_composite", "123 FAKE STREET\r\nHACKNEY\r\nE8 8EE"}
            };
            
            payloadContent.Add(contactObject);

            var response = new JObject(){
                {"@odata.context", "{CRM_SVC_URI}api/data/v8.2/$metadata#contacts"},
                {"value", payloadContent}
            };
          
            var responseTask = Task.FromResult(response);
            
            return responseTask;
        }

        Task<JObject> IDynamicsContext.FetchPatchJson(string guid)
        {
            var payloadContent = new JArray();
            var addressObject = new JObject(){
                {"hackney_shortaddress", "123 FAKE STREET"}
            };

            payloadContent.Add(addressObject);
            
            var response = new JObject(){
                {"@odata.context", "{CRM_SVC_URI}api/data/v8.2/$hackney_propertyareapatchs"},
                {"value", payloadContent}
            };
          
            var responseTask = Task.FromResult(response);
            
            return responseTask;        }    
    }
}
