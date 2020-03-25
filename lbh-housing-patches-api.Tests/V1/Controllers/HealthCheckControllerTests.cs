using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using lbh_housingpatches_api.Controllers.V1;

namespace UnitTests.V1.Controllers
{

    [TestFixture]
    public class HealthCheckControllerTests
    {
        private HealthCheckController _classUnderTest;


        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new HealthCheckController();
        }

        [Test]
        public void ReturnsResponseWithStatus()
        {
            var response = _classUnderTest.HealthCheck() as OkObjectResult;

            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(200));
            Assert.That(new Dictionary<string, object> {{"success", true}}, Is.EqualTo(response.Value));
        }
    }
}
