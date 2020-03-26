using System.Collections.Generic;
using System.Linq;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Gateways;
using NUnit.Framework;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class ContactsGatewayTest
    {
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
            var houseRef = "FakeHouseRef";
            var personno = "FakePersonNo";
            var contact = _classUnderTest.GetContactsByReference(houseRef, personno);

            Assert.That(contact, Is.InstanceOf<List<Contact>>());
        }

        [Test]
        public void GetContactsByReference_WithReference_ReturnsCorrectContactAddress()
        {
            var houseRef = "FakeHouseRef";
            var personno = "FakePersonNo";
            var uprn = "FakeUprn";
            var address = "FakeAddress";
            var contact = _classUnderTest.GetContactsByReference(houseRef, personno);

            Assert.That(contact.Count, Is.Not.EqualTo(0));
            Assert.That(contact.First(), Has.Property("HouseRef"));
            Assert.That(contact.First(), Has.Property("HouseRef").EqualTo(houseRef));
            Assert.That(contact.First(), Has.Property("Uprn").Not.Null);
            Assert.That(contact.First(), Has.Property("Uprn").EqualTo(uprn));
            Assert.That(contact.First(), Has.Property("Address").Not.Null);
            Assert.That(contact.First(), Has.Property("Address").EqualTo(address));
        }
    }
}