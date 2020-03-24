using NUnit.Framework;
using lbh_housingpatches_api.V1.Factories;
using lbh_housingpatches_api.V1.Domain;
using Newtonsoft.Json.Linq;

namespace UnitTests.V1.Factories
{
    [TestFixture]
    public class ContactsFactoryTests
    {
        [Test]
        public void ContactFactory_ReturnsNewContact()
        {
            var jsonResponse = new JObject();
            var contact = new ContactFactory().FromJsonObject(jsonResponse);

            Assert.That(contact, Is.InstanceOf<Contact>());
        }
    }
}