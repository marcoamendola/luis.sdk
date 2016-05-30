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

    public static class ActionFixtures
    {
        public static void InitializeActionBuilder(IFixture fixture)
        {
            fixture.Customize<Sdk.Contract.Action>(ob => ob
                .Without(x => x.ID)
                .Do(x => x.Parameters.AddMany(fixture.Create<ActionParameter>, 3))
            );
        }

        public static async Task<string> PersistNewAction(this IFixture fixture, ILuisServiceClient client)
        {
            var appId = await fixture.EnsureTestApp(client);

            var intent = fixture.Create<Intent>();
            var entities = fixture.CreateMany<Entity>(3);
            var action = fixture.Create<Sdk.Contract.Action>();
            action.IntentName = intent.Name;
            action.Parameters.Zip(entities, 
                (p, e) => { p.EntityName = e.Name; return (object)null; }
                ).ToArray();
            
            foreach(var e in entities)
                await client.AddEntityAsync(appId, e);
            await client.AddIntentAsync(appId, intent);
            return await client.AddActionAsync(appId, action);
        }


        public static async Task ClearTestActions(this IFixture fixture, ILuisServiceClient client, string appId)
        {
            var actions = await client.GetActionsAsync(appId);
            foreach (var action in actions)
            {
                await client.DeleteActionAsync(appId, action.ID);                
            }
        }
    }
}
