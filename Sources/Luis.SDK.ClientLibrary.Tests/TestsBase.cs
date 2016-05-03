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

        protected LuisServiceClient _sut;
        protected Fixture _fixture;

        [TestInitialize]
        public virtual void Initialize()
        {
            var d = Directory.GetCurrentDirectory();
            System.Diagnostics.Debug.Print(d);
            var key = File.ReadLines("SubscriptionKey.secret").FirstOrDefault();
            key.Should().NotBeNullOrWhiteSpace();

            _sut = new LuisServiceClient(key);
        }
    }
}
