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
        public static void InitializeEntityBuilder(IFixture fixture)
        {
            fixture.Customize<Entity>(ob => ob
                .Without(x => x.ID)
                .Without(x => x.Type)
            );
        }

        public static async Task<string> PersistNewEntity(this IFixture fixture, ILuisServiceClient client, string name = null)
        {
            var entity = fixture.Create<Entity>();
            if (name != null) entity.Name = name;
            var appId = await fixture.EnsureTestApp(client);
            return await client.AddEntityAsync(appId, entity);
        }


        public static readonly string[] TEST_ENTITY_NAMES = new string[] {
            "__TestEntity_A",
            "__TestEntity_B",
            "__TestEntity_C"
            };
        public static async Task ClearTestEntities(this IFixture fixture, ILuisServiceClient client, string appId)
        {
            var entities = await client.GetEntitiesAsync(appId);
            foreach (var entity in entities)
            {
                if (!TEST_ENTITY_NAMES.Contains(entity.Name))
                {
                    await client.DeleteEntityAsync(appId, entity.ID);
                }
            }
        }
        static string[] s_testEntitiesIds;
        public static async Task<string[]> EnsureTestEntities(this IFixture fixture, ILuisServiceClient client, string appId)
        {
            if (s_testEntitiesIds != null) return s_testEntitiesIds;

            var entities = (await client.GetEntitiesAsync(appId))
                .Where(a => TEST_ENTITY_NAMES.Contains(a.Name))
                .ToArray();

            if (!entities.Any())
            {
                s_testEntitiesIds = await Task.WhenAll(
                    from n in TEST_ENTITY_NAMES
                    select fixture.PersistNewEntity(client, n)
                );
            }
            else
            {
                s_testEntitiesIds = entities.Select(e => e.ID).ToArray();
            }

            return s_testEntitiesIds;
        }
    }
}
