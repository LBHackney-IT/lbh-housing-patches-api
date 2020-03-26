using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Gateways;
using NUnit.Framework;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class ContactsGatewayTest
    {
        private ContactsGateway _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new ContactsGateway();
        }

        [Test]
        public void ContactsGateway_WithSingleInput_ReturnsSingleContact()
        {
            var contact = _classUnderTest.GetContactsByReference();

            Assert.That(contact, Is.InstanceOf<Contact>());
        }
    }
}