using Microsoft.ProjectOxford.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luis.Sdk.Contract;

namespace Luis.Sdk
{
    public class LuisServiceClient : RestServiceClient, ILuisServiceClient
    {
        public LuisServiceClient(string subscriptionKey)
        {
            ApiRoot = "https://api.projectoxford.ai/luis/v1.0/prog/";
            AuthKey = "Ocp-Apim-Subscription-Key";
            AuthValue = subscriptionKey;
        }

        public async Task<App> GetAppAsync(string appId)
        {
            return await this.GetAsync<Null, App>($"apps/{appId}", Null.Value);
        }
        public async Task<App[]> GetAppsAsync()
        {
            return await this.GetAsync<Null, App[]>("apps", Null.Value);
        }
        public async Task<string> AddAppAsync(App app)
        {
            return await this.PostAsync<App, string>("apps", app);
        }
        public async Task UpdateAppAsync(App app)
        {
            await this.PutAsync<App, Null>($"apps/{app.ID}", app);
        }
        public async Task DeleteAppAsync(string appId)
        {
            await this.DeleteAsync<Null, Null>($"apps/{appId}", Null.Value);
        }

        public async Task<Entity> GetEntityAsync(string appId, string entityId)
        {
            return await this.GetAsync<Null, Entity>($"apps/{appId}/entities/{entityId}", Null.Value);
        }
        public async Task<Entity[]> GetEntitiesAsync(string appId)
        {
            return await this.GetAsync<Null, Entity[]>($"apps/{appId}/entities", Null.Value);
        }
        public async Task<string> AddEntityAsync(string appId, Entity entity)
        {
            return await this.PostAsync<Entity, string>($"apps/{appId}/entities", entity);
        }
        public async Task RenameEntityAsync(string appId, string entityId, string newName)
        {
            await this.PutAsync<Entity, Null>($"apps/{appId}/entities/{entityId}",
                new Entity { Name = newName });
        }
        public async Task DeleteEntityAsync(string appId, string entityId)
        {
            await this.DeleteAsync<Null, Null>($"apps/{appId}/entities/{entityId}", Null.Value);
        }
    }

}
