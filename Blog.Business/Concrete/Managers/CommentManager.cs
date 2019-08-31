using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;
using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete.Managers
{
   public class CommentManager:ICommentService
   {
       private ICommentDal _commentDal;
       public CommentManager(ICommentDal commentDal)
       {
           _commentDal = commentDal;
       }
        public List<Comment> GetAll()
        {
           return _commentDal.GetAll();
        }
        public Comment GetNewObject()
        {
            return new Comment();
        }
        public Comment Get(int id)
        {
            return _commentDal.Get(id);
        }

        public Comment Add(Comment entity)
        {
           return _commentDal.Add(entity);
        }

        public void Delete(Comment entity)
        {
             _commentDal.Delete(entity);
        }

        public Comment Update(Comment entity)
        {
            return _commentDal.Update(entity);
        }

        public List<Comment> GetAllByPostId(int postId)
        {
           return _commentDal.GetAllByPostId(postId);
        }

        public List<Comment> GetLatestComments()
        {
            return _commentDal.GetLatestComments();
        }
    }
}
