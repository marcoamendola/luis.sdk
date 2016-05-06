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
        
    }
}
