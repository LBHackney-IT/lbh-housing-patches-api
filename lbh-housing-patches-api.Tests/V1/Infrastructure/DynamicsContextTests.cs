using System;
using lbh_housingpatches_api.V1.Infrastructure;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace UnitTests.V1.Infrastructure
{
    [TestFixture]
    public class DynamicsContextTests
    {
        private DynamicsContext _dynamicsContext;

        [SetUp]
        public void SetUp()
        {
            _dynamicsContext = new DynamicsContext();
        }
        [Test]
        public void FetchContactsJson_FetchesJson()
        {
            var testUprn = "testUPRN";
            var contextResponse = _dynamicsContext.FetchContactsJSon(testUprn).Result;

            Assert.That(contextResponse, Is.Not.Null);
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
