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
            //fixture.Customize<Entity>(ob => ob
            //    .With(x => x.ID, null)
            //    .With(x => x.Culture, new CultureInfo("it-it"))
            //);
        }

        public static async Task<string> CreateNewEntity(this IFixture fixture, ILuisServiceClient client)
        {
            //var app = fixture.Create<Entity>();
            //return await client.AddAppAsync(app);
            return null;
        }

    }
}
