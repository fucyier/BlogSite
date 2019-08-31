using Blog.Core;
using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Abstract
{
    public interface ICommentDal : IEntityRepository<Comment>
    {
        List<Comment> GetAllByPostId(int postId);
        List<Comment> GetLatestComments();
    }
}
