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
        Task AddAppAsync(App app);
    }
}
