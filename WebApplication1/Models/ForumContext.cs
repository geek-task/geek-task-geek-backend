using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ForumContext : DbContext
    {
        public DbSet<User> Users { set; get; }

        public DbSet<Topic> Topics { set; get; }

        public DbSet<Post> Posts { set; get; }
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
            Database.EnsureCreated();   //created database if not exist
        }
    }
}
