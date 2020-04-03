using System.Linq;
using lbh_housingpatches_api.V1.Factories;
using lbh_housingpatches_api.V1.Infrastructure;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Factories
{
    [TestFixture]
    public class ContactFactoryTests
    {
        private IDynamicsContext _dynamicsContext;
        
        [SetUp]
        public void SetUp()
        {
            _dynamicsContext = new DynamicsContextStub();
        }

        [Test]
        public void CanBeCreatedFromJsonObject()
        {
            var firstContactJson = _dynamicsContext.FetchContactsJSon("100088888888").Result;

            var contactFromFactory = new ContactFactory().FromJsonContacts(firstContactJson).First();

            var jsonHouseRef = firstContactJson["value"][0]["hackney_houseref"].ToString();
            var jsonUprn = firstContactJson["value"][0]["hackney_uprn"].ToString();
            var jsonAddress = firstContactJson["value"][0]["address1_composite"].ToString();

            Assert.That(contactFromFactory.HouseRef, Is.EqualTo(jsonHouseRef));
            Assert.That(contactFromFactory.Uprn, Is.EqualTo(jsonUprn));
            Assert.That(contactFromFactory.Address, Is.EqualTo(jsonAddress));
        }
    }
}
