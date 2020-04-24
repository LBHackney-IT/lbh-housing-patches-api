using System;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Gateways;
using lbh_housingpatches_api.V1.Infrastructure;
using NUnit.Framework;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class PatchesGatewayTests
    {
        private string guid = Guid.NewGuid().ToString();
        private IDynamicsContext _dynamicsContext;
        private IPatchesGateway _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _dynamicsContext = new DynamicsContextStub();
            _classUnderTest = new PatchesGateway();
        }

        [Test]
        public void GetPatchByGuid_WithInput_ReturnsSinglePatch()
        {
            var patch = _classUnderTest.GetPatchByGuid(guid);

            Assert.That(patch, Is.InstanceOf<Patch>());
        }
    } 
}