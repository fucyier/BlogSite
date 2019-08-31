using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Configurations
{
    class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
           
            Property(c => c.CommenterMail).HasMaxLength(100);         
            Property(c => c.Message).HasMaxLength(1000).IsRequired();
            Property(c => c.CommenterName).HasMaxLength(50);
            HasRequired(c => c.Post).WithMany(p => p.Comments).HasForeignKey(c => c.PostId);
            Property(c => c.RootId).HasColumnName("RootId");
            HasOptional(c => c.RootComment).WithMany().HasForeignKey(c => c.RootId);




        }
    }
}
