using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Abstract
{
   public interface ITagService
    {      
           List<Tag> GetAll();
        List<Tag> GetAllwithPosts();

        Tag Get(int id);

           Tag Add(Tag entity);

           void Delete(Tag entity);

           Tag Update(Tag entity);
          
    }
}
