using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.OutModels
{
    public class TopicOut
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public TopicOut()
        {

        }
        public TopicOut(int Id,string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
