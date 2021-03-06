﻿using Luis.Sdk.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.Sdk
{
    public interface ILuisServiceClient
    {
        Task<App[]> GetAppsAsync();
        Task<App> GetAppAsync(string appId);
        Task<string> AddAppAsync(App app);
        Task UpdateAppAsync(App app);
        Task DeleteAppAsync(string appId);

        Task<Entity[]> GetEntitiesAsync(string appId);
        Task<Entity> GetEntityAsync(string appId, string entityId);
        Task<string> AddEntityAsync(string appId, Entity entity);
        Task RenameEntityAsync(string appId, string entityId, string newName);
        Task DeleteEntityAsync(string appId, string entityId);

        Task<Intent[]> GetIntentsAsync(string appId);
        Task<Intent> GetIntentAsync(string appId, string intentId);
        Task<string> AddIntentAsync(string appId, Intent intent);
        Task RenameIntentAsync(string appId, string intentId, string newName);
        Task DeleteIntentAsync(string appId, string intentId);

        Task<Contract.Action[]> GetActionsAsync(string appId);
        Task<Contract.Action> GetActionAsync(string appId, string actionId);
        Task<string> AddActionAsync(string appId, Contract.Action action);
        Task UpdateActionAsync(string appId, Contract.Action action);
        Task DeleteActionAsync(string appId, string actionId);
    }
}
