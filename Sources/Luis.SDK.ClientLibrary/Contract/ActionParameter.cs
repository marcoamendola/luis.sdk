using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.Sdk.Contract
{
    public class ActionParameter
    {
        public string ParameterId { get; set; }
        public string ParameterName { get; set; }
        public string EntityName { get; set; }
        public string Question { get; set; }
        public bool Required { get; set; }
        public int Order { get; set; }
        public string PhraseListId { get; set; }
    }
}
