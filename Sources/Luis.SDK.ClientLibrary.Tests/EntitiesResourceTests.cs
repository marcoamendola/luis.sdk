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
    public class EntitiesResourceTests : TestClassWithAppBase
    {
        
        [TestMethod]
        public async Task Can_create_an_Entity()
        {
            var countBefore = (await _sut.GetEntitiesAsync(_testAppId)).Length;

            var entity = _fixture.Freeze<Entity>();
            var newId = await _fixture.PersistNewEntity(_sut);

            var entities = await _sut.GetEntitiesAsync(_testAppId);
            entities.Length.Should().Be(countBefore + 1);
            var added = entities.SingleOrDefault(a => a.ID == newId);
            added.Should().NotBeNull();

            added.ID.Should().Be(newId);
            added.Name.Should().Be(entity.Name);
            added.Type.Should().Be("Entity Extractor");
        }


        [TestMethod]
        public async Task Can_rename_an_Entity()
        {
            var entId = await _fixture.PersistNewEntity(_sut);

            var newName = _fixture.Create<string>();
            await _sut.RenameEntityAsync(_testAppId, entId, newName);

            var updated = await _sut.GetEntityAsync(_testAppId, entId);

            updated.Name.Should().Be(newName);
        }

        [TestMethod]
        public async Task Can_delete_an_Entity()
        {
            var countBefore = (await _sut.GetEntitiesAsync(_testAppId)).Length;
            var newId = await _fixture.PersistNewEntity(_sut);

            await _sut.DeleteEntityAsync(_testAppId, newId);

            var entities = await _sut.GetEntitiesAsync(_testAppId);
            entities.Length.Should().Be(countBefore);
            entities.Any(e => e.ID == newId).Should().BeFalse();
        }

        [TestMethod]
        public async Task Can_get_single_Entity()
        {
            var expected = _fixture.Freeze<Entity>();
            var newId = await _fixture.PersistNewEntity(_sut);

            var entity = await _sut.GetEntityAsync(_testAppId, newId);

            entity.Should().NotBeNull();
            entity.ID.Should().Be(newId);
            entity.Name.Should().Be(expected.Name);
        }

        [TestMethod]
        public void Should_throw_when_getting_unexisting_Entity()
        {
            var id = _fixture.Create<string>();

            _sut.Awaiting(s => s.GetEntityAsync(_testAppId, id))
                .ShouldThrow<Microsoft.ProjectOxford.Common.ClientException>();
        }

        [TestMethod]
        public async Task Can_list_Entities()
        {
            await _fixture.PersistNewEntity(_sut);
            var entities = (await _sut.GetEntitiesAsync(_testAppId)).ToArray();
            entities.Should().NotBeEmpty();
        }
         
    }
}
