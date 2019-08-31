using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Models
{
    public class BlogWebUIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BlogWebUIContext() : base("name=BlogWebUIContext")
        {
        }

        public System.Data.Entity.DbSet<Blog.Domain.Concrete.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<Blog.Domain.Concrete.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<Blog.Domain.Concrete.PostDetail> PostDetails { get; set; }

        public System.Data.Entity.DbSet<Blog.Domain.Concrete.Tag> Tags { get; set; }
    }
}
