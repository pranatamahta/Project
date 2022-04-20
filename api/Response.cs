using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api
{
    public class Response
    {
        public string message { get; set; }
        public List<Test01> data { get; set; }
    }
}
