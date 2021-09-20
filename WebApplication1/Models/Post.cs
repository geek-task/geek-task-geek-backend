using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Post
    {
        public int Id { set; get; }

        [Required (ErrorMessage = "Please fill description!")]
        public string Description { set; get; }

        public int? topicId { set; get; }
        public int? userId { set; get; }

        public User user { set; get; }
        
        public Topic topic { set; get; }

        public Post(int Id, string Description, int topicId,int userId)
        {
            this.Id = Id;
            this.Description = Description;
            this.topicId = topicId;
            this.userId = userId;
        }
        public Post()
        {

        }
    }
}
