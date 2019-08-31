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
    public class EfAuthorDal : IAuthorDal
    {
        public List<Author> GetAll()
        {
            using (var context = new BlogContext())
            {
                return context.Authors.Include(x => x.User).ToList();
            }
        }

        public Author Get(int id)
        {
            using (var context = new BlogContext())
            {
                return context.Authors.SingleOrDefault(x => x.AuthorId == id);
            }
        }

        public Author Add(Author entity)
        {
            using (var context = new BlogContext())
            {
                context.Authors.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Author entity)
        {
            using (var context = new BlogContext())
            {
                var author = context.Authors.Find(entity.AuthorId);
                if (author != null)
                {
                    context.Authors.Remove(author);
                    context.SaveChanges();
                }
            }
        }

        public Author Update(Author entity)
        {
            using (var context = new BlogContext())
            {
                var author = context.Authors.FirstOrDefault(d => d.AuthorId == entity.AuthorId);
                author.AuthorInfo = entity.AuthorInfo;
                author.AuthorMail = entity.AuthorMail;
                author.AuthorName = entity.AuthorName;
                author.UserId = entity.UserId;
                if (entity.AuthorPhoto != null && author.AuthorPhoto != entity.AuthorPhoto)
                {
                    author.AuthorPhoto = entity.AuthorPhoto;
                    author.ImageMimeType = entity.ImageMimeType;
                }
                author.AuthorStatus = entity.AuthorStatus;
                author.AuthorCreationDate = entity.AuthorCreationDate;

                //context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return author;
            }
        }

        public void EditStatus(string id, bool statu)
        {
            using (var context = new BlogContext())
            {
                Author a = context.Authors.Include(x => x.User).Where(u => u.UserId == id).FirstOrDefault();
                a.AuthorStatus = statu;
                context.SaveChanges();
            }
        }
    }
}
