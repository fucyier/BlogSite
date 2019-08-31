using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Configurations
{
    class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            HasKey(p=>p.PostId);
            Property(p=>p.PostTitle).IsRequired().HasColumnName("Title").HasMaxLength(500);
            Property(p => p.PostShortDetail).HasColumnName("ShortDetail").HasMaxLength(1000);
            Property(p=>p.PostDate).IsRequired().HasColumnType("datetime2");
            Property(p => p.PostTitleImage).HasColumnName("TitleImageData");
            Property(p => p.ImageMimeType).HasMaxLength(50);
            HasRequired(p => p.Author).WithMany(p => p.Posts).HasForeignKey(p=>p.AuthorId);
            ToTable("Posts");

        }
    }
}
