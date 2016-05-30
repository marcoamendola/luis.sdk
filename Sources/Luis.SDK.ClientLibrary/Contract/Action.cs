using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.Sdk.Contract
{
    public class Action
    {
        [JsonProperty("ActionId")]
        public string ID { get; set; }
        [JsonProperty("ActionName")]
        public string Name { get; set; }
        public string IntentName { get; set; }
        [JsonProperty("ActionParameters")]
        public IList<ActionParameter> Parameters { get; private set; } = new List<ActionParameter>();
        public string Dialog { get; set; }
        public string Channel { get; set; }
    }
}
