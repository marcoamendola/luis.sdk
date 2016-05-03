using FluentAssertions;
using Luis.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.SDK.ClientLibrary.Tests
{
    public abstract class TestsBase
    {
        static TestsBase()
        {
            //ignore SSL certificate errors in tests to allow Fiddler inspection
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, errors) => { return true; };
        }
        
        protected LuisServiceClient _sut;
        protected Fixture _fixture = new Fixture();
        
        [TestInitialize]
        public virtual void Initialize()
        {
            var key = File.ReadLines("SubscriptionKey.secret").FirstOrDefault();
            key.Should().NotBeNullOrWhiteSpace();

            _sut = new LuisServiceClient(key);
        }
    }
}
