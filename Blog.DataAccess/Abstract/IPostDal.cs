using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core;
using Blog.Domain.Concrete;

namespace Blog.DataAccess.Abstract
{
    public interface IPostDal:IEntityRepository<Post>
    {
        void RaiseViewCount(int postId,int value);
        List<Post> GetByTagId(int? tagId);
        List<Post> GetMostCommentedPosts();
        List<Post> GetMostViewedPosts();
        Post GetPreviousPost(int postId);
        Post GetNextPost(int postId);
        Post Add(Post entity, string[] selectedTags);
        Post Update(Post entity, string[] selectedTags);
    }
}
