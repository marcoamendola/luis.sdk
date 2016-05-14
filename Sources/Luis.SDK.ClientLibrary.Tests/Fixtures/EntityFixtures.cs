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

    public static class EntityFixtures
    {
        public static void CustomizeEntityBuilder(this IFixture fixture)
        {
            fixture.Customize<Entity>(ob => ob
                .Without(x => x.ID)
                .Without(x => x.Type)
            );
        }

        public static async Task<string> PersistNewEntity(this IFixture fixture, ILuisServiceClient client)
        {
            var entity = fixture.Create<Entity>();
            var appId = await fixture.EnsureTestApp(client);
            return await client.AddEntityAsync(appId, entity);
        }

    }
}
