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
    public class TagManager : ITagService
    {
        private readonly ITagDal _tagDal;
        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }
        public List<Tag> GetAll()
        {
            return _tagDal.GetAll();
        }
        public List<Tag> GetAllwithPosts()
        {
            return _tagDal.GetAllwithPosts();
        }
        public Tag Get(int id)
        {
           return _tagDal.Get(id);
        }

        public Tag Add(Tag entity)
        {
            return _tagDal.Add(entity);
        }

        public void Delete(Tag entity)
        {
            _tagDal.Delete(entity);
        }

        public Tag Update(Tag entity)
        {
            return _tagDal.Update(entity);
        }
    }
}
