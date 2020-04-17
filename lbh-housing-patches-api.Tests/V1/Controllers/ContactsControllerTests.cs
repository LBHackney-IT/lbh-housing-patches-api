using System;
using System.Linq;
using lbh_housingpatches_api.V1.Boundary;
using lbh_housingpatches_api.V1.Controllers;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Gateways;
using lbh_housingpatches_api.V1.UseCase;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Controllers
{
    [TestFixture]
    public class ContactsControllerTests
    {
        private ContactsController _classUnderTest;
        private ContactsRequest _contactsRequest;

        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new ContactsController(new ListContacts(new ContactsGateway(new DynamicsContextStub())));
            _contactsRequest = new ContactsRequest
            {
                Uprn = "100088888888"
            };
        }

        [Test]
        public void GetContacts_ReturnsResponseWithStatus()
        {
            var response = _classUnderTest.GetContacts(_contactsRequest);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void GetContacts_ReturnsJsonResult()
        {
            var response = _classUnderTest.GetContacts(_contactsRequest);

            Assert.That(response, Is.InstanceOf<JsonResult>());
        }

        [Test]
        public void GetContacts_ReturnsJsonResultContainingContactEntities()
        {
            var response = _classUnderTest.GetContacts(_contactsRequest);
            var contactsResponse = response.Value as ContactsResponse;
            var firstContact = contactsResponse.Contacts[0];

            Assert.That(firstContact, Is.InstanceOf<Contact>());
        }

        [Test]
        public void GetContacts_ContactEntitiesPropertiesArePopulated()
        {
            var response = _classUnderTest.GetContacts(_contactsRequest);
            var contactsResponse = response.Value as ContactsResponse;
            var firstContact = contactsResponse.Contacts[0];

            Assert.That(firstContact.HouseRef, Is.Not.Null);
            Assert.That(firstContact.Uprn, Is.Not.Null);
            Assert.That(firstContact.Address, Is.Not.Null);
        }

        [Test]
        public void GetContacts_WithoutArguments_ReturnsError()
        {
            var _badContactsRequest = new ContactsRequest
            {
                Uprn = null
            };

            Assert.That(() => { _classUnderTest.GetContacts(_badContactsRequest); },
                Throws.ArgumentNullException);
            Assert.That(() => { _classUnderTest.GetContacts(_badContactsRequest); },
                Throws.ArgumentNullException.With.Property("Message"));
        }
    }
}
