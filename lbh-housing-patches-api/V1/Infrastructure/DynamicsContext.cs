using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lbh_housingpatches_api.V1.Infrastructure
{
    public class DynamicsContext : IDynamicsContext
    {
        public HttpClient Client { get; set; }

        public JObject Contacts
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public JObject FetchContactsJSon(string houseRef, string personno)
        {
            throw new NotImplementedException();
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
