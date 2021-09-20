using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Topic
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int? userId { set; get; }
        public User user { set; get; }
    }
}
