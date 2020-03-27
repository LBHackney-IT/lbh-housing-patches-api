using System.Linq;
using lbh_housingpatches_api.V1.Factories;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace UnitTests.V1.Factories
{
    [TestFixture]
    public class ContactFactoryTests
    {
        [Test]
        public void CanBeCreatedFromJsonObject()
        {
            var contactJson = new JObject
            {
                {"hackney_houseref", "House Ref"},
                {"hackney_uprn", "UPRN"},
                {"address1_composite", "Composite Address"}
            };

            var contact = new ContactFactory().FromJsonContacts(contactJson).First();

            var jsonHouseRef = contactJson["hackney_houseref"].ToString();
            var jsonUprn = contactJson["hackney_uprn"].ToString();
            var jsonAddress = contactJson["address1_composite"].ToString();

            Assert.That(contact.HouseRef, Is.EqualTo(jsonHouseRef));
            Assert.That(contact.Uprn, Is.EqualTo(jsonUprn));
            Assert.That(contact.Address, Is.EqualTo(jsonAddress));
        }
    }
}
