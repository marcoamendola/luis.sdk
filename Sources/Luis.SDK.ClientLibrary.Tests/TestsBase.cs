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
            var key = GetSubscriptionKey();
            _sut = new LuisServiceClient(key);
        }

        protected string GetSubscriptionKey()
        {
            const string SubscriptionKeyFileName = "SubscriptionKey.secret";

            if (!File.Exists(SubscriptionKeyFileName))
                throw new Exception($"Ensure that a file named {SubscriptionKeyFileName} is present in the tests' bin directory");

            var key = File.ReadLines(SubscriptionKeyFileName).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(key) || key == "xxxx-xxxx-xxxx-xxxx")
                throw new Exception($"Please ensure that the file named {SubscriptionKeyFileName} contains the subscription key");

            return key;
        }
    }


}
