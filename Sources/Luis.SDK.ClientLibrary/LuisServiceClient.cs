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

        #region App
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
        #endregion

        #region Entity
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
        #endregion

        #region Intent
        public async Task<Intent[]> GetIntentsAsync(string appId)
        {
            return await this.GetAsync<Null, Intent[]>($"apps/{appId}/intents", Null.Value); 
        }
        public async Task<Intent> GetIntentAsync(string appId, string intentId)
        {
            return await this.GetAsync<Null, Intent>($"apps/{appId}/intents/{intentId}", Null.Value);
        }
        public async Task<string> AddIntentAsync(string appId, Intent intent)
        {
            return await this.PostAsync<Intent, string>($"apps/{appId}/intents", intent);
        }
        public async Task RenameIntentAsync(string appId, string intentId, string newName)
        {
            await this.PutAsync<Intent, Null>($"apps/{appId}/intents/{intentId}",
                new Intent { Name = newName });
        }
        public async Task DeleteIntentAsync(string appId, string intentId)
        {
            await this.DeleteAsync<Null, Null>($"apps/{appId}/intents/{intentId}", Null.Value);
        }
        #endregion

        #region Action
        public async Task<Contract.Action[]> GetActionsAsync(string appId)
        {
            return await this.GetAsync<Null, Contract.Action[]>($"apps/{appId}/actions", Null.Value);
        }
        public async Task<Contract.Action> GetActionAsync(string appId, string actionId)
        {
            return await this.GetAsync<Null, Contract.Action>($"apps/{appId}/actions/{actionId}", Null.Value);
        }
        public async Task<string> AddActionAsync(string appId, Contract.Action action)
        {
            return await this.PostAsync<Contract.Action, string>($"apps/{appId}/actions", action);
        }
        public async Task UpdateActionAsync(string appId, Contract.Action action)
        {
            await this.PutAsync<Contract.Action, Null>($"apps/{appId}/actions/{action.ID}", action);
        }
        public async Task DeleteActionAsync(string appId, string actionId)
        {
            await this.DeleteAsync<Null, Null>($"apps/{appId}/actions/{actionId}", Null.Value);
        }
        #endregion
    }

}
