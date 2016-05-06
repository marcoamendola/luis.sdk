using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.Sdk.Contract
{
    public class App
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(CultureInfoJsonConverter))]
        public CultureInfo Culture { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime PublishDate { get; set; }
        public Uri URL { get; set; }
        public string AuthKey { get; set; }
        public int NumberOfIntents { get; set; }
        public int NumberOfEntities { get; set; }
        public bool IsTrained { get; set; }
    }

}
