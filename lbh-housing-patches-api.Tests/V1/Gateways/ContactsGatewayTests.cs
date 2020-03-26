using System.Collections.Generic;
using System.Linq;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Gateways;
using NUnit.Framework;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class ContactsGatewayTest
    {
        private ContactsGateway _classUnderTest;
        const string housingref = "0900318";
        const string personno = "2";

        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new ContactsGateway();
        }

        [Test]
        public void GetContactsByReference_WithInput_ReturnsContactList()
        {

            var contact = _classUnderTest.GetContactsByReference(housingref, personno);

            Assert.That(contact, Is.InstanceOf<List<Contact>>());
        }

        [Test]
        public void GetContactsByReference_WithReference_ReturnsCorrectContacts()
        {
            var contact = _classUnderTest.GetContactsByReference(housingref, personno);

            Assert.That(contact.Count, Is.Not.EqualTo(0));
            Assert.That(contact.First(), Has.Property("HousingRef"));
            Assert.That(contact.First(), Has.Property("HousingRef").EqualTo(housingref));
            Assert.That(contact.First(), Has.Property("Uprn").Not.Null);
        }
    }
}