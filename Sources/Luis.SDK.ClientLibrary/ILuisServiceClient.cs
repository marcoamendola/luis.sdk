using Luis.Sdk.Contract;
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

    }
}
