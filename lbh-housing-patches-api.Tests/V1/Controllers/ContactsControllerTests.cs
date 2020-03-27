using System;
using System.Linq;
using lbh_housingpatches_api.V1.Boundary;
using lbh_housingpatches_api.V1.Controllers;
using lbh_housingpatches_api.V1.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;

namespace UnitTests.V1.Controllers
{
    [TestFixture]
    public class ContactsControllerTests
    {
        private ContactsController _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new ContactsController();
        }

        [Test]
        public void GetContacts_ReturnsResponseWithStatus()
        {
            var response = _classUnderTest.GetContacts();

            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void GetContacts_ReturnsJsonResult()
        {
            var response = _classUnderTest.GetContacts();

            Assert.That(response, Is.InstanceOf<JsonResult>());
        }

        [Test]
        public void GetContacts_ReturnsJsonResultContainingContactEntities()
        {
            var response = _classUnderTest.GetContacts();
            var contactsResponse = response.Value as ContactsResponse;
            var firstContact = contactsResponse.Contacts[0];

            Assert.That(firstContact, Is.InstanceOf<Contact>());
        }

        [Test]
        public void GetContacts_ContactEntitiesPropertiesArePopulated()
        {
            var response = _classUnderTest.GetContacts();
            var contactsResponse = response.Value as ContactsResponse;
            var firstContact = contactsResponse.Contacts[0];

            Assert.That(firstContact.HouseRef, Is.Not.Null);
            Assert.That(firstContact.Uprn, Is.Not.Null);
            Assert.That(firstContact.Address, Is.Not.Null);
        }
    }
}
