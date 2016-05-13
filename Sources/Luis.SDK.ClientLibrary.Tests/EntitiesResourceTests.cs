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
    public class EntitiesResourceTests : TestsBase
    {
        string _testAppId;
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            _fixture.CustomizeAppBuilder();
            _fixture.CustomizeEntityBuilder();

            _testAppId = _fixture.EnsureTestApp(_sut).Result;
        }

        protected async override Task RemoveObject(string id)
        {
            await _sut.DeleteEntityAsync(_testAppId, id);
        }


        [TestMethod]
        public async Task Can_create_an_Entity()
        {
            var countBefore = (await _sut.GetEntitiesAsync(_testAppId)).Length;

            var entity = _fixture.Freeze<Entity>();
            var newId = await CreateTestEntity();

            var entities = await _sut.GetEntitiesAsync(_testAppId);
            entities.Length.Should().Be(countBefore + 1);
            var added = entities.SingleOrDefault(a => a.ID == newId);
            added.Should().NotBeNull();

            added.ID.Should().Be(newId);
            added.Name.Should().Be(entity.Name);
            added.Type.Should().Be("Entity Extractor");
        }


        //[TestMethod]
        //public async Task Can_rename_an_Entity()
        //{
        //    var entId = await _fixture.PersistNewEntity(_sut);

        //    var newName = _fixture.Create<string>();
        //    await _sut.RenameEntityAsync(entId, newName);

        //    var updated = await _sut.GetEntityAsync(entId);

        //    updated.Name.Should().Be(newName);            
        //}

        //[TestMethod]
        //public async Task Can_delete_an_Entity()
        //{
        //    var countBefore = (await _sut.GetEntitiesAsync()).Length;
        //    var newId = await _fixture.CreateNew(_sut);

        //    await _sut.DeleteAppAsync(newId);

        //    var apps = await _sut.GetAppsAsync();
        //    apps.Length.Should().Be(countBefore);
        //    apps.Any(a => a.ID == newId).Should().BeFalse();
        //}

        //[TestMethod]
        //public async Task Can_get_single_Entity()
        //{
        //    var newId = await _fixture.PersistNewApp(_sut);

        //    var app = await _sut.GetAppAsync(newId);

        //    app.Should().NotBeNull();
        //    app.ID.Should().Be(newId);
        //}

        //[TestMethod]
        //public void Should_throw_when_getting_unexisting_Entity()
        //{
        //    var id = _fixture.Create<string>();

        //    _sut.Awaiting(s => s.GetEntityAsync(id))
        //        .ShouldThrow<Microsoft.ProjectOxford.Common.ClientException>();
        //}

        //[TestMethod]
        //public async Task Can_list_Apps()
        //{
        //    await _fixture.PersistNewApp(_sut);
        //    var apps = (await _sut.GetAppsAsync()).ToArray();
        //    apps.Should().NotBeEmpty();
        //}

        private async Task<string> CreateTestEntity()
        {
            var newId = await _fixture.PersistNewEntity(_sut);
            _remover.Register(newId);
            return newId;
        }
    }
}
