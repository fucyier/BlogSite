using Blog.DataAccess.Abstract;
using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete.EntityFramework
{
   public class EfTagDal:ITagDal
    {
        public List<Tag> GetAll()
        {
            using (var context = new BlogContext())
            {
                var tag = context.Tags.ToList();
                return tag;
            }
        }
        public List<Tag> GetAllwithPosts()
        {
            using (var context = new BlogContext())
            {
                var tag = context.Tags.Include(x => x.Posts).ToList();
                return tag;
            }
        }
        public Tag Get(int id)
        {
            using (var context=new BlogContext())
            {
                var tag = context.Tags.Where(t => t.TagId == id).SingleOrDefault();
                return tag;
            }
        }

        public Tag Add(Tag entity)
        {
            using (var context = new BlogContext())
            {
                context.Tags.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Tag entity)
        {
            using (var context = new BlogContext())
            {
                var tag = context.Tags.Find(entity.TagId);
                if (tag != null)
                {
                    context.Tags.Remove(tag);
                    context.SaveChanges();
                }
            }
        }

        public Tag Update(Tag entity)
        {
            using (var context = new BlogContext())
            {
                var tag = context.Tags.FirstOrDefault(d => d.TagId == entity.TagId);
                tag.TagText = entity.TagText;
              

                //context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return tag;
            }
        }
    }
}
