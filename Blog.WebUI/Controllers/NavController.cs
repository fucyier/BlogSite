using Blog.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.WebUI.Models;

namespace Blog.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IPostService _postService;
        private ITagService _tagService;
        private ICommentService _commentService;
        public NavController(IPostService postService, ITagService tagService, ICommentService commentService)
        {
            _postService = postService;
            _tagService = tagService;
            _commentService = commentService;
        }
        public ActionResult Index(int? postTagId, int page = 1)
        {
            var posts = postTagId.HasValue ? _postService.GetByTagId(postTagId).Count > 0 ? _postService.GetByTagId(postTagId) : _postService.GetAll() : _postService.GetAll();

            PostsListViewModel postsModel = new PostsListViewModel()
            {
                Posts = posts.Skip((page - 1) * 10).Take(10),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = 10,
                    TotalItems = posts.Count(),
                    TotalPageCount = (int)Math.Ceiling((decimal)posts.Count() / 10),
                },
                TagId = postTagId,
                TagText = postTagId.HasValue ? _tagService.Get(postTagId.Value)!=null ? _tagService.Get(postTagId.Value).TagText: "All" : "All"
            };
            return View(postsModel);
        }
        [ChildActionOnly]
        public PartialViewResult GetTopPosts()
        {
            var posts = _postService.GetAll().OrderByDescending(x=>x.PostDate).Take(5);
            return PartialView(posts);
        }
        [ChildActionOnly]
        public PartialViewResult FeaturedPosts()
        {
            var posts = _postService.GetAll().Where(x => x.PostStatus == true && x.IsFeatured == true).Take(5);
            return PartialView("GetFeaturedPosts", posts);
        }
        [ChildActionOnly]
        public PartialViewResult FeaturedMenuTopics()
        {
            var posts = _postService.GetAll().Where(x => x.PostStatus == true && x.IsFeatured == true).Take(10);
            return PartialView("FeaturedMenuTopics", posts);
        }
        [ChildActionOnly]
        public PartialViewResult MostCommentedPosts()
        {
            var posts = _postService.GetMostCommentedPosts();
            return PartialView("MostCommentedPosts", posts);
        }
        [ChildActionOnly]
        public PartialViewResult MostViewedPosts()
        {
            var posts = _postService.GetMostViewedPosts().Take(5);
            return PartialView("MostViewedPosts", posts);
        }
        [ChildActionOnly]
        public PartialViewResult GetAllTags()
        {
            var tags = _tagService.GetAll();
            return PartialView("GetAllTags", tags);
        }
        [ChildActionOnly]
        public PartialViewResult TopTabs()
        {

            var tags = _tagService.GetAll().OrderByDescending(tag => tag.TagId).Take(4);
            return PartialView("TopTabs", tags);
        }
        [ChildActionOnly]
        public PartialViewResult SelectedTopics(int TagId)
        {

            var posts = _postService.GetByTagId(TagId).Take(4);
            return PartialView("SelectedTopics", posts);
        }
        [ChildActionOnly]
        public PartialViewResult LatestDiscussion()
        {

            var comments = _commentService.GetLatestComments().Take(5);
            return PartialView("LatestDiscussion", comments);
        }

        [ChildActionOnly]
        public PartialViewResult MenuTagTopics()
        {
            var tags = _tagService.GetAllwithPosts();
            //var posts = _postService.GetByTagId(TagId).Take(4);
            return PartialView("MenuTagTopics", tags);
        }
    }
}