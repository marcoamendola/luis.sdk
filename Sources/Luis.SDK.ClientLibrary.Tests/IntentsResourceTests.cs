using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Luis.Sdk.Contract;
using Ploeh.AutoFixture;
using FluentAssertions;
using System.Linq;
using System.Globalization;
using Luis.SDK.ClientLibrary.Tests.Fixtures;

namespace Luis.SDK.ClientLibrary.Tests
{
    [TestClass]
    public class IntentsResourceTests : TestClassWithAppBase
    {
        
        [TestMethod]
        public async Task Can_create_an_Intent()
        {
            var countBefore = (await _sut.GetIntentsAsync(_testAppId)).Length;

            var intent = _fixture.Freeze<Intent>();
            var newId = await _fixture.PersistNewIntent(_sut);

            var intents = await _sut.GetIntentsAsync(_testAppId);
            intents.Length.Should().Be(countBefore + 1);
            var added = intents.SingleOrDefault(a => a.ID == newId);
            added.Should().NotBeNull();

            added.ID.Should().Be(newId);
            added.Name.Should().Be(intent.Name);
            added.Type.Should().Be("Intent Classifier");
        }


        [TestMethod]
        public async Task Can_rename_an_Intent()
        {
            var intentId = await _fixture.PersistNewIntent(_sut);

            var newName = _fixture.Create<string>();
            await _sut.RenameIntentAsync(_testAppId, intentId, newName);

            var updated = await _sut.GetIntentAsync(_testAppId, intentId);

            updated.Name.Should().Be(newName);
        }

        [TestMethod]
        public async Task Can_delete_an_Intent()
        {
            var countBefore = (await _sut.GetIntentsAsync(_testAppId)).Length;
            var newId = await _fixture.PersistNewIntent(_sut);

            await _sut.DeleteIntentAsync(_testAppId, newId);

            var intents = await _sut.GetIntentsAsync(_testAppId);
            intents.Length.Should().Be(countBefore);
            intents.Any(e => e.ID == newId).Should().BeFalse();
        }

        [TestMethod]
        public async Task Can_get_single_Intent()
        {
            var expected = _fixture.Freeze<Intent>();
            var newId = await _fixture.PersistNewIntent(_sut); 
            var intent = await _sut.GetIntentAsync(_testAppId, newId);

            intent.Should().NotBeNull();
            intent.ID.Should().Be(newId);
            intent.Name.Should().Be(expected.Name);
        }

        [TestMethod]
        public void Should_throw_when_getting_unexisting_Intent()
        {
            var id = _fixture.Create<string>();

            _sut.Awaiting(s => s.GetIntentAsync(_testAppId, id))
                .ShouldThrow<Microsoft.ProjectOxford.Common.ClientException>();
        }

        [TestMethod]
        public async Task Can_list_Intents()
        {
            await _fixture.PersistNewIntent(_sut);
            var intents = (await _sut.GetIntentsAsync(_testAppId)).ToArray();
            intents.Should().NotBeEmpty();
        }

        
    }
}
