using Blog.DataAccess.Abstract;
using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Blog.DataAccess.Concrete.EntityFramework
{
   public class EfCommentDal:ICommentDal
    {
        public List<Comment> GetAll()
        {
            using (var context=new BlogContext())
            {
                var comments = from c in context.Comments
                              
                               orderby c.CommentDate descending
                               select c;
                return comments.ToList();

            }
        }

        public List<Comment> GetLatestComments()
        {
            using (var context = new BlogContext())
            {
                var comments = (from c in context.Comments.Include(x=>x.Post)
                               where c.Status == true orderby c.CommentDate descending
                               select c).ToList();
                return comments.ToList();

            }
        }

        public Comment Get(int id)
        {
            using (var context=new BlogContext())
            {
               var comment= (from c in context.Comments
                            where c.CommentId==id
                select c).FirstOrDefault();
                return comment;
            }
        }

        public Comment Add(Comment entity)
        {
            using (var context = new BlogContext())
            {
                context.Comments.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Comment entity)
        {
            using (var context = new BlogContext())
            {
                var comment = context.Comments.Find(entity.CommentId);
                if (comment != null)
                {
                    context.Comments.Remove(comment);
                    context.SaveChanges();
                }
            }
        }

        public Comment Update(Comment entity)
        {
            using (var context = new BlogContext())
            {
                var comment = context.Comments.FirstOrDefault(x=>x.CommentId== entity.CommentId);
                comment.CommenterName = entity.CommenterName;
                comment.CommenterMail = entity.CommenterMail;
                comment.CommentDate = entity.CommentDate;
                comment.Message = entity.Message;
                comment.PostId = entity.PostId;
                comment.Status = entity.Status;
                context.SaveChanges();
                return comment;
            }
        }

        public List<Comment> GetAllByPostId(int postId)
        {
            using (var context=new BlogContext())
            {
                var comments = (from c in context.Comments.Include(c=>c.ChildComments).Include(c=>c.RootComment)
                               where c.Status == true && c.PostId == postId
                               select c).ToList();
                return comments;
            }
        }
    }
}
