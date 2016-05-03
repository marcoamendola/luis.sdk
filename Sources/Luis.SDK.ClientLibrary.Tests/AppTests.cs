using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Luis.Sdk.Contract;
using Ploeh.AutoFixture;
using FluentAssertions;
using System.Linq;
using System.Globalization;

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

            var app = _fixture.Build<App>()
                .Without(a => a.ID)
                .With(a => a.Culture, new CultureInfo("it-it"))
                .Create();

            var newId = await _sut.AddAppAsync(app);
            _createdAppsIds.Add(newId);

            var apps = await _sut.GetAppsAsync();
            apps.Length.Should().Be(countBefore + 1);

            var added = apps.SingleOrDefault(a => a.ID == newId);
            added.Should().NotBeNull();
            added.ShouldBeEquivalentTo(app);
        }

        [TestMethod]
        public async Task Can_delete_an_App()
        {
            var countBefore = (await _sut.GetAppsAsync()).Length;

            var app = _fixture.Build<App>()
                .With(a => a.Culture, new CultureInfo("it-it"))
                .Create();

            var newId = await _sut.AddAppAsync(app);
            _createdAppsIds.Add(newId);

            await _sut.DeleteAppAsync(newId);

            var apps = await _sut.GetAppsAsync();
            apps.Length.Should().Be(countBefore);

            var deleted = apps.SingleOrDefault(a => a.ID == newId);
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
