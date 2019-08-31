using Blog.Core;
using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Abstract
{
   public interface ITagDal : IEntityRepository<Tag>
    {
        List<Tag> GetAllwithPosts();
    }
}
