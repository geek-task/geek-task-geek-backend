    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.OutModels
{
    public class PostOut
    {
        public int Id { set; get; }

        public string description { set; get; }

        public TopicOut topic { set; get; }
        public UserOut user {set;get;}

        public PostOut(int Id,string description,TopicOut topic,UserOut user)
        {
            this.Id = Id;
            this.description = description;
            this.topic = topic;
            this.user = user;
        }
        public PostOut()
        {

        }
    }
}
