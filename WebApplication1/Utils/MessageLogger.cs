using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Utils
{
    public class MessageLogger
    {
        public string message { set; get; }
        public string data { set; get; }
        public MessageLogger()
        {

        }
        public MessageLogger(string message)
        {
            this.message = message;
        }
        public MessageLogger(string message,string data)
        {
            this.message = message;
            this.data = data;
        }
    }
}
