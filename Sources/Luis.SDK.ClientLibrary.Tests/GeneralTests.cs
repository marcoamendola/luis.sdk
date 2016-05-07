using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Luis.SDK.ClientLibrary.Tests
{
    [TestClass]
    public class GeneralTests: TestsBase
    {
        [TestMethod]
        public void Can_create_client_instance()
        {
            //intentionally do nothing
        }
        
        protected override Task RemoveObject(string id)
        {
            throw new NotSupportedException();
        }
    }
}
