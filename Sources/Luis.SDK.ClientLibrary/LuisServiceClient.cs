using Microsoft.ProjectOxford.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.Sdk
{
    public class LuisServiceClient : ServiceClient, ILuisServiceClient
    {
        public LuisServiceClient(string subscriptionKey)
        {
            ApiRoot = "https://api.projectoxford.ai/luis/v1.0/prog";
            AuthKey = "Ocp-Apim-Subscription-Key";
            AuthValue = subscriptionKey;
        }
        

        


    }


    
}
