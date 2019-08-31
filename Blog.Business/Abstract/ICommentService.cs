using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Abstract
{
   public interface ICommentService
    {
        List<Comment> GetAllByPostId(int postId);
        List<Comment> GetAll();
        List<Comment> GetLatestComments();
        Comment GetNewObject();
        Comment Get(int id);

        Comment Add(Comment entity);

        void Delete(Comment entity);

        Comment Update(Comment entity);
    }
}
