using lbh_housingpatches_api.V1.Factories;
using lbh_housingpatches_api.V1.Infrastructure;
using NUnit.Framework;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Factories
{
    public class PatchFactoryTests
    {
        private IDynamicsContext _dynamicsContext;

        [SetUp]
        public void SetUp()
        {
            _dynamicsContext = new DynamicsContextStub();
        }

        [Test]
        public void CanBeCreatedFromJsonObject()
        {
            var firstPatchJson = _dynamicsContext.FetchPatchJson("sample").Result;

            var patchFromFactory = PatchFactory.FromJsonPatch(firstPatchJson);

            var jsonAddress = firstPatchJson["value"][0]["hackney_shortaddress"].ToString();

            Assert.That(patchFromFactory.Addresses[0], Is.EqualTo(jsonAddress));
        }
    }
}