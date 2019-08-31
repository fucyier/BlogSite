using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.DataAccess.EntityFramework;
using Blog.Domain.Concrete;
using Blog.DataAccess.Abstract;
using System.Data.Entity;

namespace Blog.DataAccess.Concrete.EntityFramework
{
    public class EfPostDal : IPostDal
    {


        public List<Post> GetByTagId(int? tagId)
        {
            using (var _context = new BlogContext())
            {
                var post = (from p in _context.Posts.Include(p => p.Tags).Include(p => p.Author)
                            where p.PostStatus == true && p.Tags.Any(t => t.TagId == tagId)
                            orderby p.PostId descending
                            select p).ToList();

                return post;

            }
        }
        public List<Post> GetAll()
        {
            using (var _context = new BlogContext())
            {

                List<Post> post = (from p in _context.Posts.Include(p => p.Tags).Include(p => p.Author)
                                   where p.PostStatus == true
                                   orderby p.PostId descending
                                   select p).ToList();

                return post;
            }

        }
        public List<Post> GetMostCommentedPosts()
        {
            using (var _context = new BlogContext())
            {
                var posts = (from p in _context.Posts.Include(c => c.Comments)
                             where p.PostStatus == true
                             orderby p.Comments.Count() descending
                             select p).Take(5).ToList();
                return posts;
            }

        }
        public List<Post> GetMostViewedPosts()
        {
            using (var _context = new BlogContext())
            {

                List<Post> post = (from p in _context.Posts.Include(p => p.Tags).Include(p => p.Author)
                                   where p.PostStatus == true
                                   orderby p.ViewCount descending
                                   select p).ToList();

                return post;
            }
        }
        public Post Get(int postId)
        {
            using (var _context = new BlogContext())
            {
                Post post = (from p in _context.Posts.Include(p => p.Tags).Include(p => p.Author).Include(p => p.PostDetail).Include(p => p.Comments)
                             where p.PostStatus == true && p.PostId == postId
                             select p).Single();
                return post;
            }

        }
        public Post GetPreviousPost(int postId)
        {
            using (var _context = new BlogContext())
            {
                var pos = _context.Posts.OrderByDescending(p => p.PostId).AsEnumerable()
                .SkipWhile(p => p.PostId != postId).Skip(1).FirstOrDefault();
                //  previousPostId = previousPostId ?? postId;
                int previousPostId = (pos == null ? postId : pos.PostId);
                Post post = (from p in _context.Posts.Include(p => p.Tags).Include(p => p.Author).Include(p => p.PostDetail)
                             where p.PostStatus == true && p.PostId == previousPostId
                             select p).Single();

                return post;
            }

        }
        public Post GetNextPost(int postId)
        {
            using (var _context = new BlogContext())
            {


                var pos = _context.Posts.OrderBy(p => p.PostId).AsEnumerable()
                .SkipWhile(p => p.PostId != postId).Skip(1).FirstOrDefault();
                int nextPostId = (pos == null ? postId : pos.PostId);
                Post post = (from p in _context.Posts.Include(p => p.Tags).Include(p => p.Author).Include(p => p.PostDetail)
                             where p.PostStatus == true && p.PostId == nextPostId
                             select p).Single();

                return post;
            }

        }

        public void RaiseViewCount(int postId, int value)
        {
            using (var _context = new BlogContext())
            {
                var post = _context.Posts.SingleOrDefault(p => p.PostId == postId);
                post.ViewCount += value;
                _context.SaveChanges();
            }


        }



        public Post Add(Post entity, string[] selectedTags)
        {
            using (var _context = new BlogContext())
            {

                if (selectedTags != null)
                {
                    foreach (var tag in selectedTags)
                    {
                        int tagId = int.Parse(tag);
                        Tag tagToAdd = _context.Tags.FirstOrDefault(x => x.TagId == tagId);
                        _context.Tags.Attach(tagToAdd);
                        entity.Tags.Add(tagToAdd);
                    }
                }
               ;
                _context.Posts.Add(entity);
                _context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Post entity)
        {
            using (var _context = new BlogContext())
            {
                var post = _context.Posts.Include(p => p.Tags).Include(p => p.Author).Include(p => p.PostDetail).Include(p => p.Comments).First(x => x.PostId == entity.PostId);
                if (post != null)
                {
                    _context.Posts.Remove(post);
                    _context.SaveChanges();
                }
            }
        }

        public Post Update(Post entity, string[] selectedTags)
        {
            using (var _context = new BlogContext())
            {
                if (selectedTags != null)
                {
                    foreach (var tag in selectedTags)
                    {
                        int tagId = int.Parse(tag);
                        Tag tagToAdd = _context.Tags.FirstOrDefault(x => x.TagId == tagId);
                        _context.Tags.Attach(tagToAdd);
                        entity.Tags.Add(tagToAdd);
                    }
                }

                var post = _context.Posts.Include(p => p.Tags).Include(p => p.Author).Include(p => p.PostDetail).Include(p => p.Comments).FirstOrDefault(d => d.PostId == entity.PostId);
                post.PostTitle = entity.PostTitle;
                post.PostShortDetail = entity.PostShortDetail;
                post.PostStatus = entity.PostStatus;
                if (entity.PostTitleImage != null && post.PostTitleImage != entity.PostTitleImage)
                {
                    post.PostTitleImage = entity.PostTitleImage;
                    post.ImageMimeType = entity.ImageMimeType;
                }
                post.IsFeatured = entity.IsFeatured;
                post.AuthorId = entity.AuthorId;
                post.PostDate = entity.PostDate;
                post.PostDetail = entity.PostDetail;
                post.Tags = entity.Tags;

                _context.SaveChanges();
                return post;
            }
        }

        public Post Update(Post entity)
        {
            throw new NotImplementedException();
        }

        public Post Add(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
