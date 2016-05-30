using Luis.SDK.ClientLibrary.Tests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.SDK.ClientLibrary.Tests
{
    public abstract class TestClassWithAppBase: TestClassBase
    {

        protected string _testAppId;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            _testAppId = _fixture.EnsureTestApp(_sut).Result;
        }

        [TestCleanup]
        public override void Cleanup()
        {
            AppFixtures.InvalidateTestApp();
        }
    }
}
