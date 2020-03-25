using lbh_housingpatches_api.V1.Controllers;
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
        // [Test]
        // public void ReturnsContact()
        // {
        //     var response = _classUnderTest.GetContacts();

        //     Assert.That(response, Is.InstanceOf<Contact>());
        // }
    }
}