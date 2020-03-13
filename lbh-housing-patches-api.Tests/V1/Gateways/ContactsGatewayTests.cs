using lbh_housingpatches_api.V1.Boundary;
using NUnit.Framework;
using lbh_housingpatches_api.V1.Gateways;
using lbh_housingpatches_api.V1.Infrastructure;
using Moq;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class ContactsGatewayTests
    {
        private Mock<IXrmContext> _xrmContext;
        private ContactsGateway   _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _xrmContext     = new Mock<IXrmContext>();
            _classUnderTest = new ContactsGateway(_xrmContext.Object);
        }

        [Test]
        public void GetContactForAttribute_WithValidContactId_GivesResponse()
        {
            var request  = new RetrieveContactsRequest();
            var response = _classUnderTest.GetContactForAttribute(request);

            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public void WithAnyContactId_GivesExpectedResponseType()
        {
            var request  = new RetrieveContactsRequest();
            var response = _classUnderTest.GetContactForAttribute(request);

            Assert.That(response, Is.InstanceOf<RetrieveContactsResponse>());
        }

        // TODO:
        [Test]
        public void GetContactForAttribute_WithSpecificContactId_GivesExpectedResponse()
        {
            var request  = new RetrieveContactsRequest();
            var response = _classUnderTest.GetContactForAttribute(request);

            Assert.That(response, Contains.Item(new { }));
        }
    }
}
