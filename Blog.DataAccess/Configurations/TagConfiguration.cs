using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Configurations
{
    class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(t => t.TagText).IsRequired().HasMaxLength(50).IsUnicode(true);
            HasMany(t => t.Posts).WithMany(p => p.Tags)
                .Map(c =>
                {
                    c.ToTable("PostTags");
                    c.MapLeftKey("TagId");
                    c.MapRightKey("PostId");
                });
        }
    }
}
