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
    public class PostsController : ControllerBase
    {
        private readonly ForumContext _context;

        public PostsController(ForumContext context)
        {
            _context = context;
        }

        [Authorize]
        [Route("post")]
        [HttpPost]
        public ActionResult createPost(Post post) //create post in topic!
        {
            try
            {
                var userId = Int32.Parse(User.Identity.Name);
                post.userId = userId;
                _context.Posts.Add(post);
                _context.SaveChanges();
                return Ok(new MessageLogger(Messages.POST_SUCCESSFULLY_CREATED));
            }
            catch(Exception ex)
            {
                return BadRequest(new MessageLogger(ex.ToString())); 
            }
        }

        [Route("posts")] //get all posts
        [HttpGet]
        public ActionResult<List<PostOut>> getAllPosts() //serialize (password)!?
        {
            return _context.Posts.Include(t => t.topic).Include(t => t.user).Select(v =>
                new PostOut(v.Id, v.Description, new TopicOut(v.topic.Id, v.topic.Name),
                new UserOut(v.user.Id, v.user.FirstName, v.user.LastName))).ToList();
        }

        [Route("post")] //update post by user
        [Authorize]
        [HttpPut]
        public ActionResult updatePost(PostIn post)
        {
            var userId = Int32.Parse(User.Identity.Name);

            var postObj = _context.Posts.FirstOrDefault(v => v.Id == post.Id && v.userId == userId);

            if (postObj != null)
            {
                postObj.Description = post.Description;
                _context.Entry(postObj).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new MessageLogger(Messages.POST_SUCCESSFULLY_UPDATED));
            }

            return BadRequest(new MessageLogger(Messages.POST_NOT_FOUND_PROTECT));
        }

    }
}
