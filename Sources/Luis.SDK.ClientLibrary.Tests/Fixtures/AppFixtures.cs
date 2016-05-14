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
        public static void CustomizeAppBuilder(this IFixture fixture)
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

        public const string TEST_APP_NAME = "TestApp__ab0848e14aec4ccdad768aa08c221f8e";

        static string s_testAppId;
        public static async Task<string> EnsureTestApp(this IFixture fixture, ILuisServiceClient client)
        {
            if (s_testAppId != null) return s_testAppId;

            var app = (await client.GetAppsAsync())
                .Where(a => a.Name == TEST_APP_NAME)
                .SingleOrDefault();

            if (app == null)
            {
                s_testAppId = await fixture.PersistNewApp(client, TEST_APP_NAME);
            }
            else
            {
                s_testAppId = app.ID;
            }
            return s_testAppId;
        }
    }
}



