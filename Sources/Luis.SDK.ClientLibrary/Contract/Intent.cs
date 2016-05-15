using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.Sdk.Contract
{
    public class Intent
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        //found in json, but always empty
        //public List<object> children { get; set; }
    }
}
