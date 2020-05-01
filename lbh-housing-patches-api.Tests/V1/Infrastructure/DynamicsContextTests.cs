using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using lbh_housingpatches_api.V1.Infrastructure;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace UnitTests.V1.Infrastructure
{
    [TestFixture]
    public class DynamicsContextTests
    {
        private DynamicsContext _dynamicsContext;
        private Mock<HttpMessageHandler> _messageHandler;

        [SetUp]
        public void SetUp()
        {
            _messageHandler = new Mock<HttpMessageHandler>();
            _messageHandler.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()
                )
                        .Returns((HttpRequestMessage request, CancellationToken cancellationToken) => 
                            GetMockResponse(request, cancellationToken));

            _dynamicsContext = new DynamicsContext(_messageHandler.Object);
        }

        private Task<HttpResponseMessage> GetMockResponse(HttpRequestMessage request, CancellationToken cancellationToken)
        { 
            if (request.RequestUri.LocalPath == "//api/data/v8.2/contacts" || 
                request.RequestUri.LocalPath == "//api/data/v8.2/hackney_propertyareapatchs")
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                var payload = 
@"{
    'request': {
        'uprn': '10001111111'
    },
    'generatedAt': " + $"{DateTime.Now}" + @"
    'contacts': [
    ]
}";
                payload = payload.Replace('\u0027', '\u0022');
                response.Content = new StringContent(payload, Encoding.UTF8, "application/json");
                Console.WriteLine(payload);
                return Task.FromResult(response);
            }
            throw new NotImplementedException();
        }

        [Test]
        public void FetchContactsJson_FetchesJson()
        {
            var testUprn = "testUPRN";
            var contextResponse = _dynamicsContext.FetchContactsJSon(testUprn).Result;

            Console.WriteLine("??????????????????" + contextResponse);
            // Assert.That(contextResponse, Is.EqualTo(3));
            Assert.That(contextResponse, Is.InstanceOf<JObject>());
        }

        [Test]
        public void FetchPatchJson_FetchesJson()
        {
            var guid = Guid.NewGuid().ToString();
            var contextResponse = _dynamicsContext.FetchPatchJson(guid).Result;

            Assert.That(contextResponse, Is.Not.Null);
            Assert.That(contextResponse, Is.InstanceOf<JObject>());
        }
    }
}
