using Luis.Sdk;
using Luis.Sdk.Contract;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Dsl;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.SDK.ClientLibrary.Tests.Fixtures
{

    public static class AppFixtures
    {
        public static void InitializeAppBuilder(IFixture fixture)
        {
            fixture.Customize<App>(ob => ob
                .Without(x => x.ID)
                .With(x => x.Culture, new CultureInfo("it-it"))
            );
        }

        public static async Task<string> PersistNewApp(this IFixture fixture, ILuisServiceClient client, string name = null)
        {
            var app = fixture.Create<App>();
            if (name != null) app.Name = name;
            return await client.AddAppAsync(app);
        }

        public const string TEST_APP_NAME = "__TestApp";
        static string s_testAppId;
        public static void InvalidateTestApp() {
            s_testAppId = null;
        }
        public static async Task<string> EnsureTestApp(this IFixture fixture, ILuisServiceClient client)
        {
            if (s_testAppId != null) return s_testAppId;

            var app = (await client.GetAppsAsync())
                .Where(a => a.Name == TEST_APP_NAME)
                .SingleOrDefault();

            if (app == null)
            {
                s_testAppId = await fixture.PersistNewApp(client, TEST_APP_NAME);

            } else {

                s_testAppId = app.ID;
                await fixture.ClearTestActions(client, s_testAppId);
                await fixture.ClearTestIntents(client, s_testAppId);
                await fixture.ClearTestEntities(client, s_testAppId);
            }

            await fixture.EnsureTestIntent(client, s_testAppId);
            await fixture.EnsureTestEntities(client, s_testAppId);
            
            return s_testAppId;
        }
    }
}



