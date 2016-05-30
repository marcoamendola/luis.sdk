using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Luis.SDK.ClientLibrary.Tests.Fixtures;

namespace Luis.SDK.ClientLibrary.Tests
{
    [TestClass]
    public class GeneralTests : TestClassBase
    {
        [TestMethod]
        public void Can_create_client_instance()
        {
            //intentionally do nothing
        }

        [TestMethod]
        public async Task Can_ensure_Test_App()
        {
            await _fixture.EnsureTestApp(_sut);
        }

    }
}
