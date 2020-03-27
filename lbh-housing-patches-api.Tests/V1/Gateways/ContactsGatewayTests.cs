using System.Collections.Generic;
using System.Linq;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Factories;
using lbh_housingpatches_api.V1.Gateways;
using NUnit.Framework;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class ContactsGatewayTest
    {
        private const string houseRef = "FakeHouseRef";
        private const string personNo = "FakePersonNo";
        private const string uprn = "FakeUprn";
        private const string address = "FakeAddress";

        private ContactsGateway _classUnderTest;
        private DynamicsContextStub _dynamicsContext;

        [SetUp]
        public void SetUp()
        {
            _dynamicsContext = new DynamicsContextStub();
            _classUnderTest = new ContactsGateway(_dynamicsContext);
        }

        [Test]
        public void GetContactsByReference_WithInput_ReturnsContactList()
        {
            var contact = _classUnderTest.GetContactsByReference(houseRef, personNo);

            Assert.That(contact, Is.InstanceOf<List<Contact>>());
        }

        [Test]
        public void GetContactsByReference_WithReference_ReturnsCorrectContactAddress()
        {
            var contactsList = _classUnderTest.GetContactsByReference(houseRef, personNo);
            var contact = contactsList.First();

            Assert.That(contactsList.Count(), Is.Not.EqualTo(0));

            Assert.That(contact, Has.Property("HouseRef"));
            Assert.That(contact, Is.Not.Null);
            Assert.That(contact, Has.Property("HouseRef").EqualTo(houseRef));
            Assert.That(contact, Has.Property("Uprn").Not.Null);
            Assert.That(contact, Has.Property("Uprn").EqualTo(uprn));
            Assert.That(contact, Has.Property("Address").Not.Null);
            Assert.That(contact, Has.Property("Address").EqualTo(address));
        }
    }
}
