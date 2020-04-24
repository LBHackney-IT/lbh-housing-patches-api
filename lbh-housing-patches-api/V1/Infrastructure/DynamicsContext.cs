using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lbh_housingpatches_api.V1.Infrastructure
{
    public class DynamicsContext : IDynamicsContext
    {
        private HttpClient _client;
        public string CrmUri = Environment.GetEnvironmentVariable("CRM_SVC_URI") + "/api/data/v8.2/";

        public DynamicsContext()
        {
            _client = GetCrmClient();
        }

        public async Task<JObject> FetchContactsJSon(string uprn)
        {
            Console.WriteLine(CrmUri);
            var requestUri = new Uri(
                $@"{CrmUri}contacts?fetchXml=
                <fetch version = '1.0' output-format='xml-platform' distinct='true'>
                    <entity name='contact'>
                        <attribute name='hackney_uprn' />
                        <attribute name='hackney_houseref' />
                        <attribute name='address1_composite' />
                        <filter>
                            <condition attribute='hackney_uprn' operator='eq' value='{uprn}' />
                        </filter>
                    </entity>    
                </fetch>"
                );
            Console.WriteLine(requestUri);
            var response = await _client.GetStringAsync(requestUri);
            Console.WriteLine(response);
            return JsonConvert.DeserializeObject<JObject>(response);
        }

        public async Task<JObject> FetchPatchJson(string guid)
        {
            var guidString = Guid.NewGuid();
            var requestUri = new Uri(
                $@"{CrmUri}hackney_propertyareapatchs?fetchXml=
                <fetch version = '1.0' output-format='xml-platform' distinct='true'>
                    <entity name='hackney_propertyareapatch'>
                        <attribute name='hackney_propertyareapatchid' />
                        <attribute name='hackney_estateaddress' />
                        <filter>
                            <condition attribute='hackney_propertyareapatchid' operator='eq' value=""116c941e-9a53-e811-8123-70106faa0331"" />
                        </filter>
                    </entity>
                </fetch>"
            );

            var response = await _client.GetStringAsync(requestUri);

            return JsonConvert.DeserializeObject<JObject>(response);
        }

        private static HttpClient GetCrmClient()
        {
            var authorizationUrl = Environment.GetEnvironmentVariable("CRM_AUTH_URI");
            var organizationUrl = Environment.GetEnvironmentVariable("CRM_SVC_URI");

            var accessToken = GetAuthToken(authorizationUrl);
            var client = new HttpClient {BaseAddress = new Uri(organizationUrl)};

            client.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            client.DefaultRequestHeaders.Add("OData-Version", "4.0");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            client.DefaultRequestHeaders.Add("Prefer", "return=representation");
            client.DefaultRequestHeaders.Add("Prefer",
                "odata.include-annotations=\"OData.Community.Display.V1.FormattedValue\"");

            return client;
        }

        public static string GetAuthToken(string authorizationUrl)
        {
            var token = JsonConvert.DeserializeObject<JObject>(new HttpClient()
                .GetAsync(authorizationUrl)
                .Result
                .Content
                .ReadAsStringAsync()
                .Result);

            return token["result"].ToString();
        }
    }
}
