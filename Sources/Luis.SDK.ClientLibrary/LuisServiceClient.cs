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

        public async Task<string> AddAppAsync(App app)
        {
            return await this.PostAsync<App, string>("apps", app);
        }

        public async Task DeleteAppAsync(string appId)
        {
            await this.DeleteAsync<Null, Null>($"apps/{appId}", Null.Value);
        }

        public async Task<App[]> GetAppsAsync()
        {
            return await this.GetAsync<Null, App[]>("apps", Null.Value);
        }

    }

}
