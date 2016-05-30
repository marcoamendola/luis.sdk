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
        public static void InitializeIntentBuilder(IFixture fixture)
        {
            fixture.Customize<Intent>(ob => ob
                .Without(x => x.ID)
                .Without(x => x.Type)
            );
        }

        public static async Task<string> PersistNewIntent(this IFixture fixture, ILuisServiceClient client, string name = null)
        {
            var intent = fixture.Create<Intent>();
            if (name != null) intent.Name = name;
            var appId = await fixture.EnsureTestApp(client);
            return await client.AddIntentAsync(appId, intent);
        }

        public const string TEST_INTENT_NAME = "__TestIntent";
        public const string NONE_INTENT_NAME = "None";
        public static async Task ClearTestIntents(this IFixture fixture, ILuisServiceClient client, string appId)
        {

            var intents = await client.GetIntentsAsync(appId);
            foreach (var intent in intents)
            {
                if (intent.Name != TEST_INTENT_NAME && intent.Name != NONE_INTENT_NAME)
                {
                    await client.DeleteIntentAsync(appId, intent.ID);
                }
            }
        }
        static string s_testIntentId;
        public static async Task<string> EnsureTestIntent(this IFixture fixture, ILuisServiceClient client, string appId)
        {
            if (s_testIntentId != null) return s_testIntentId;

            var intent = (await client.GetIntentsAsync(appId))
                .Where(a => a.Name == TEST_INTENT_NAME)
                .SingleOrDefault();

            if (intent == null)
            {
                s_testIntentId = await fixture.PersistNewIntent(client, TEST_INTENT_NAME);
            }
            else
            {
                s_testIntentId = intent.ID;
            }
            return s_testIntentId;
        }
    }

}
