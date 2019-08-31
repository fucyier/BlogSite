using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Abstract
{
   public interface IPostService
   {
       List<Post> GetAll();

       Post Get(int id);
       Post GetNewObject();
       Post Add(Post entity,string[] selectedTags);

       void Delete(Post entity);
       void RaiseViewCount(int postId,int value);

       Post Update(Post entity, string[] selectedTags);
       List<Post> GetByTagId(int? tagId);
       List<Post> GetMostCommentedPosts();
       List<Post> GetMostViewedPosts();
       Post GetPreviousPost(int postId);
       Post GetNextPost(int postId);
    }
}
