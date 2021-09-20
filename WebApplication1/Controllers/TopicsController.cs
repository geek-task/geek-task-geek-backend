using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.OutModels;
using WebApplication1.Utils;

namespace WebApplication1.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TopicsController : Controller
    {
        private readonly ForumContext _context;

        public TopicsController(ForumContext context)
        {
            _context = context;
        }

        [Route("topics")]
        [HttpGet] //get all Topics
        public ActionResult<List<TopicOut>> getAllTopics()
        {
            return _context.Topics.Select(v => new TopicOut(v.Id,v.Name)).ToList();
        }
        
        [Route("topic")]
        [Authorize]
        [HttpPost] //create topic
        public ActionResult createTopic(Topic topic)
        {
            topic.userId = Int32.Parse(User.Identity.Name);
            _context.Topics.Add(topic);
            _context.SaveChanges();
            return Ok(new MessageLogger(Messages.TOPIC_SUCCESSFULLY_CREATED));
        }

        [HttpGet("topic/id/{id}")] //all post in current topic
        public ActionResult<List<Post>> findAllPostsByTopic(int? id)
        {
            if(id!=null) 
            {
                var topic = _context.Topics.Find(id);
                if(topic!=null)
                {
                    var posts = _context.Posts.ToList().FindAll(p => p.topicId == id);
                    return posts;
                }
                return BadRequest(new MessageLogger(Messages.TOPIC_NOT_FOUND));
            }
            return BadRequest(new MessageLogger(Messages.ID_TOPIC_NOT_FOUND));
        }
    }
}
