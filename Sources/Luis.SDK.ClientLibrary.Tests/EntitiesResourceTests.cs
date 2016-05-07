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
    //[TestClass]
    //public class EntitiesResourceTests : TestsBase
    //{
    //    List<string> _createdEntitiesIds = new List<string>();


    //    [TestInitialize]
    //    public override void Initialize()
    //    {
    //        base.Initialize();
    //        _fixture.CustomizeEntityBuilder();
    //    }


    //    [TestMethod]
    //    public async Task Can_create_an_App()
    //    {
    //        var countBefore = (await _sut.GetAppsAsync()).Length;

    //        var app = _fixture.Freeze<App>();
    //        var newId = await _fixture.CreateNewApp(_sut);

    //        var apps = await _sut.GetAppsAsync();
    //        apps.Length.Should().Be(countBefore + 1);
    //        var added = apps.SingleOrDefault(a => a.ID == newId);
    //        added.Should().NotBeNull();

    //        added.ID.Should().Be(newId);
    //        added.Name.Should().Be(app.Name);
    //        added.Description.Should().Be(app.Description);
    //        added.Culture.Should().Be(app.Culture);
    //        added.AuthKey.Should().Be(GetSubscriptionKey());

    //        const int SECONDS = 1000;
    //        added.CreatedDate.Should().BeCloseTo(DateTime.UtcNow, 5 * SECONDS);
    //        added.ModifiedDate.Should().BeCloseTo(added.CreatedDate, 5 * SECONDS);
    //        added.PublishDate.Should().Be(DateTime.MinValue);

    //        added.Active.Should().BeTrue();
    //        added.IsTrained.Should().BeFalse();
    //        added.NumberOfEntities.Should().Be(0);
    //        added.NumberOfIntents.Should().Be(1);
    //        added.URL.ToString().Should().Contain(newId);
    //    }


    //    [TestMethod]
    //    public async Task Can_update_an_App()
    //    {
    //        var appId = await _fixture.CreateNewApp(_sut);

    //        var app = _fixture.Freeze<App>();
    //        app.ID = appId;
    //        await _sut.UpdateAppAsync(app);

    //        var apps = await _sut.GetAppsAsync();
    //        var updated = apps.SingleOrDefault(a => a.ID == appId);
    //        updated.Should().NotBeNull();

    //        updated.ID.Should().Be(appId);
    //        updated.Name.Should().Be(app.Name);
    //        updated.Description.Should().Be(app.Description);
    //        //updated.Culture.Should().Be(app.Culture); culture can't  change
    //        updated.AuthKey.Should().Be(GetSubscriptionKey());

    //        updated.ModifiedDate.Should()
    //            .BeAtLeast(TimeSpan.FromSeconds(1))
    //            .After(updated.CreatedDate);
    //        updated.PublishDate.Should().Be(DateTime.MinValue);

    //        updated.Active.Should().BeTrue();
    //        updated.IsTrained.Should().BeFalse();
    //        updated.NumberOfEntities.Should().Be(0);
    //        updated.NumberOfIntents.Should().Be(1);
    //        updated.URL.ToString().Should().Contain(appId);
    //    }

    //    [TestMethod]
    //    public async Task Can_delete_an_App()
    //    {
    //        var countBefore = (await _sut.GetAppsAsync()).Length;
    //        var newId = await _fixture.CreateNewApp(_sut);

    //        await _sut.DeleteAppAsync(newId);

    //        var apps = await _sut.GetAppsAsync();
    //        apps.Length.Should().Be(countBefore);
    //        apps.Any(a => a.ID == newId).Should().BeFalse();
    //    }

    //    [TestMethod]
    //    public async Task Can_get_single_App()
    //    {
    //        var newId = await _fixture.CreateNewApp(_sut);

    //        var app = await _sut.GetAppAsync(newId);

    //        app.Should().NotBeNull();
    //        app.ID.Should().Be(newId);
    //    }

    //    [TestMethod]
    //    public async Task Can_list_Apps()
    //    {
    //        await _fixture.CreateNewApp(_sut);
    //        var apps = (await _sut.GetAppsAsync()).ToArray();
    //        apps.Should().NotBeEmpty();
    //    }
        
    //    private async Task<string> CreateTestApp()
    //    {
    //        var newId = await _fixture.CreateNewApp(_sut);
    //        _createdAppsIds.Add(newId);
    //        return newId;
    //    }
    //}
}
