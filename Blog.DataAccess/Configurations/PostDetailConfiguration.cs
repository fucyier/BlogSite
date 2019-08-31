using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Configurations
{
    class PostDetailConfiguration : EntityTypeConfiguration<PostDetail>
    {
        public PostDetailConfiguration()
        {
            //HasKey(p => p.PostId);
            //HasRequired(p => p.Postof).WithRequiredPrincipal(p => p.PostDetail);
            //Property(p => p.PostId).HasColumnOrder(0);

            Property(p=>p.PostText).IsRequired();
            ToTable("PostDetails");
        }
    }
}
