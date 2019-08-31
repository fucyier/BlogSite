using Blog.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class PostController : Controller
    {
        private IPostService _postService;
        private ICommentService _commentService;
        public PostController(IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }
        public ActionResult Detail(int postId = 1)
        {
            var postDetail = _postService.Get(postId);
            _postService.RaiseViewCount(postId, 1);
            return View(postDetail);
        }
        public PartialViewResult PreviousPost(int postId = 1)
        {
            var post = _postService.GetPreviousPost(postId);
            return PartialView(post);
        }
        public PartialViewResult NextPost(int postId = 1)
        {
            var post = _postService.GetNextPost(postId);
            return PartialView(post);
        }
        [HttpGet]
        public PartialViewResult PostComments(int postId)
        {
            var comments = _commentService.GetAllByPostId(postId);
            Session["postId"] = null;
            Session["postId"] = postId;
            return PartialView("PostComments", comments);
        }

        [HttpPost]
        public PartialViewResult PostComments(string commenterName, string commenterMail, string commentMessage)
        {
            try
            {
                var comment = _commentService.GetNewObject();
                comment.CommentDate = DateTime.Now.Date;
                comment.CommenterMail = commenterMail;
                comment.CommenterName = commenterName;
                comment.Message = commentMessage;           
                comment.PostId = Convert.ToInt32(Session["postId"]);
                comment.Status = true;

                _commentService.Add(comment);
                var comments = _commentService.GetAllByPostId(Convert.ToInt32(Session["postId"]));
                return PartialView("PostComments", comments);
            
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Name, mail and message must be entered...");
               
                var comments = _commentService.GetAllByPostId(Convert.ToInt32(Session["postId"]));
                return PartialView("PostComments", comments);
            }

        }
       
        public FileContentResult GetImage(int postId)
        {
            var post = _postService.Get(postId);

            if (post != null)
            {
                if (post.PostTitleImage != null && post.ImageMimeType != null)
                {
                    return File(post.PostTitleImage, post.ImageMimeType);
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }
        [ChildActionOnly]
        public PartialViewResult RelatedItems(int? tagId)
        {
            var posts = tagId.HasValue ? _postService.GetByTagId(tagId).Take(4) : _postService.GetAll().Take(4);
            return PartialView(posts);
        }
    }
}