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
                .With(x => x.ID, null)
                .With(x => x.Culture, new CultureInfo("it-it"))
            );
        }

        public static async Task<string> CreateNewApp(this IFixture fixture, ILuisServiceClient client)
        {
            var app = fixture.Create<App>();
            return await client.AddAppAsync(app);
        }

    }
}
