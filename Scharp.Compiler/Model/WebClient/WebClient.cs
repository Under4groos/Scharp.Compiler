using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharp.Compiler.Model.WebClient
{
    public class WebClient : System.Net.WebClient
    {
        public WebClient()
        {
            this.Headers = new System.Net.WebHeaderCollection()
            {
                { "user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)" },
                { "Content-Type","application/x-www-form-urlencoded" },

            };
        }
    }
}
