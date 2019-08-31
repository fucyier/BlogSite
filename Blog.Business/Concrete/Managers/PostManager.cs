using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Business.Abstract;
using Blog.Domain.Concrete;
using Blog.DataAccess.Abstract;

namespace Blog.Business.Concrete.Managers
{
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;
        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public List<Post> GetAll()
        {
           return  _postDal.GetAll();
        }

        public Post Get(int id)
        {
            return _postDal.Get(id);
        }
        public Post GetNewObject() {
            return new Post();
        }
        public Post Add(Post entity)
        {
            return _postDal.Add(entity);
        }

        public void Delete(Post entity)
        {
            _postDal.Delete(entity);
        }

        public Post Update(Post entity)
        {
           return _postDal.Update(entity);
        }
        public Post Update(Post entity,string[] selectedTags)
        {
            return _postDal.Update(entity,selectedTags);
        }

        public List<Post> GetByTagId(int? tagId)
        {
            return _postDal.GetByTagId(tagId);
        }
        public Post GetPreviousPost(int postId)
        {
            return _postDal.GetPreviousPost(postId);
        }
        public Post GetNextPost(int postId)
        {
            return _postDal.GetNextPost(postId);
        }


        public List<Post> GetMostCommentedPosts()
        {
            return _postDal.GetMostCommentedPosts();
        }
        public List<Post> GetMostViewedPosts()
        {
            return _postDal.GetMostViewedPosts();
        }
        public void RaiseViewCount(int postId,int value)
        {
             _postDal.RaiseViewCount(postId,value);
        }

        public Post Add(Post entity, string[] selectedTags)
        {
           return _postDal.Add(entity,selectedTags);
        }
    }
}
