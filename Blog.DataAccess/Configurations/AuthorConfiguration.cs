using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Configurations
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            Property(a=>a.AuthorName).IsRequired().HasMaxLength(100).HasColumnName("Name");
            Property(a => a.AuthorMail).HasMaxLength(50).HasColumnName("Mail");
            Property(a => a.AuthorStatus).HasColumnType("bit");
            Property(a => a.AuthorCreationDate).HasColumnType("datetime2");
            Property(a => a.AuthorPhoto).HasColumnName("Photo");
            Property(a => a.AuthorInfo).HasColumnName("Info").HasMaxLength(2000);
        }
    }
}
