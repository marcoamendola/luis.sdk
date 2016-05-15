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

    public static class IntentFixtures
    {
        public static void CustomizeIntentBuilder(this IFixture fixture)
        {
            fixture.Customize<Intent>(ob => ob
                .Without(x => x.ID)
                .Without(x => x.Type)
            );
        }

        public static async Task<string> PersistNewIntent(this IFixture fixture, ILuisServiceClient client)
        {
            var intent = fixture.Create<Intent>();
            var appId = await fixture.EnsureTestApp(client);
            return await client.AddIntentAsync(appId, intent);
        }

    }
}
