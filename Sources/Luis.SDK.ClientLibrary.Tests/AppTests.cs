using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Luis.Sdk.Contract;
using Ploeh.AutoFixture;
using FluentAssertions;
using System.Linq;

namespace Luis.SDK.ClientLibrary.Tests
{
    [TestClass]
    public class AppTests : TestsBase
    {
        List<string> _createdAppsIds = new List<string>();

        [TestCleanup]
        public void Cleanup()
        {
            foreach (var id in _createdAppsIds)
            {
                try
                {
                   _sut.DeleteAppAsync(id).Wait();
                }
                catch { }
            }
        }

        [TestMethod]
        public async Task Can_create_an_App()
        {
            var countBefore = (await _sut.GetAppsAsync()).Length;

            var app = _fixture.Create<App>();
            await _sut.AddAppAsync(app);
            _createdAppsIds.Add(app.ID);

            var apps = await _sut.GetAppsAsync();
            apps.Length.Should().Be(countBefore + 1);

            var added = apps.SingleOrDefault(a => a.ID == app.ID);
            added.Should().NotBeNull();
            added.ShouldBeEquivalentTo(app);
        }

        [TestMethod]
        public async Task Can_delete_an_App()
        {
            var countBefore = (await _sut.GetAppsAsync()).Length;

            var app = _fixture.Create<App>();
            await _sut.AddAppAsync(app);
            _createdAppsIds.Add(app.ID);
            
            await _sut.DeleteAppAsync(app.ID);

            var apps = await _sut.GetAppsAsync();
            apps.Length.Should().Be(countBefore);

            var deleted= apps.SingleOrDefault(a => a.ID == app.ID);
            deleted.Should().BeNull();
        }


        [TestMethod]
        public async Task Can_list_Apps()
        {
            var apps = (await _sut.GetAppsAsync()).ToArray();
            apps.Should().NotBeEmpty();
        }
    }
}
