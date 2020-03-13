using System.Threading;
using Bogus;
using Microsoft.Extensions.HealthChecks;
using NUnit.Framework;
using lbh_housingpatches_api.UseCase.V1;
using Moq;

namespace UnitTests.V1.UseCase
{
    [TestFixture]
    public class DbHealthCheckUseCaseTests
    {
        private Mock<IHealthCheckService> _mockHealthCheckService;
        private DbHealthCheckUseCase      _classUnderTest;

        private readonly Faker  _faker = new Faker();
        private          string _description;

        [SetUp]
        public void SetUp()
        {
            _description = _faker.Random.Words();

            _mockHealthCheckService = new Mock<IHealthCheckService>();
            var compositeHealthCheckResult = new CompositeHealthCheckResult(CheckStatus.Healthy);
            compositeHealthCheckResult.Add("test", CheckStatus.Healthy, _description);


            _mockHealthCheckService.Setup(s =>
                    s.CheckHealthAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(compositeHealthCheckResult);

            _classUnderTest = new DbHealthCheckUseCase(_mockHealthCheckService.Object);
        }

        [Test]
        public void ReturnsResponseWithStatus()
        {
            var response = _classUnderTest.Execute();

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.AreEqual(response.Message, "test: " + _description);
        }
    }
}
