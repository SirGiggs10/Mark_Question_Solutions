using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mark_Question5_Solution.Dtos.Others
{
    public class ReturnResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public object ObjectValue { get; set; }
    }
}
