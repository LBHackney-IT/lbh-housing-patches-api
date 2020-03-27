using lbh_housingpatches_api.V1.Infrastructure;
using NUnit.Framework;

namespace UnitTests.V1.Infrastructure
{
    [TestFixture]
    public class DynamicsContextTests
    {
        private DynamicsContext _dynamicsContext;

        [SetUp]
        public void SetUp()
        {
            _dynamicsContext = new DynamicsContext();
        }
        [Test]
        public void FetchContactsJson_FetchesJson()
        {
            var testUprn = "test UPRN";
            var contextResponse = _dynamicsContext.FetchContactsJSon(testUprn);

            Assert.That(contextResponse, Is.Not.Null);

        }
    }
}
