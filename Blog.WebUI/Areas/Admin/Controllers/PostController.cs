using Blog.Business.Abstract;
using Blog.Domain.Concrete;
using Blog.WebUI.Areas.Admin.Models.PostModels;
using Blog.WebUI.Infrastructure;
using Blog.WebUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private IPostService _postService;
        private IAuthorService _authorService;
        private ITagService _tagService;
        public PostController(IPostService postService,IAuthorService authorService,ITagService tagService)
        {
            _postService = postService;
            _authorService = authorService;
            _tagService = tagService;
        }

        public ActionResult Index(int page = 1)
        {
            IEnumerable<Post> posts=new List<Post>();
            if (User.Identity.IsAdmin())
            {
                posts = _postService.GetAll().OrderByDescending(x => x.PostDate);
            }
            else if(User.Identity.IsAuthor())
            {
                posts = _postService.GetAll().Where(x => x.Author.UserId == User.Identity.GetUserId()).OrderByDescending(x => x.PostDate);
            }
          

            var postModel = new PostsAdminListViewModel()
            {
                Posts = posts.Skip((page - 1) * 10).Take(10),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = 10,
                    TotalItems = posts.Count(),
                    TotalPageCount = (int)Math.Ceiling((decimal)posts.Count() / 10),
                },

            };
            return View(postModel);
        }
        public ActionResult Create()
        {
            var post = _postService.GetNewObject();
            post.PostDate = DateTime.Now.Date;
            PopulateAssignedPostTag(post);

            IEnumerable<Author> authorList = User.Identity.IsAdmin() ? _authorService.GetAll() : _authorService.GetAll().Where(x => x.UserId == User.Identity.GetUserId());
            ViewBag.AuthorID = new SelectList(authorList, "AuthorId", "AuthorName");
            return View(post);
        }

      
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post,string[] selectedTags, HttpPostedFileBase image = null)
        {
            
            if (ModelState.IsValid)
            {
                
                if (image != null)
                {
                    post.ImageMimeType = image.ContentType;
                    post.PostTitleImage = new byte[image.ContentLength];
                    image.InputStream.Read(post.PostTitleImage, 0, image.ContentLength);
                }
                _postService.Add(post,selectedTags);
                return RedirectToAction("Index");
            }
            PopulateAssignedPostTag(post);
            ViewBag.AuthorID = new SelectList(_authorService.GetAll(), "AuthorId", "AuthorName",post.AuthorId);
            return View(post);
        }
        private void PopulateAssignedPostTag(Post post)
        {
            var allTags = _tagService.GetAll();
            var postTags = new HashSet<int>(post.Tags.Select(c => c.TagId));
            var assignedTagData = new List<AssignedTagData>();
            foreach (var tag in allTags)
            {
                assignedTagData.Add(new AssignedTagData
                {
                    TagID = tag.TagId,
                    TagName = tag.TagText,
                    Assigned = postTags.Contains(tag.TagId)
                });
            }
            ViewBag.Tags = assignedTagData;
        }

        public ActionResult Edit(int id)
        {
            var post = _postService.Get(id);
            PopulateAssignedPostTag(post);
            ViewBag.AuthorID = new SelectList(_authorService.GetAll(), "AuthorId", "AuthorName", post.AuthorId);
            return View(post);
        }
      
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post, string[] selectedTags, HttpPostedFileBase image = null)
        {
            
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    post.ImageMimeType = image.ContentType;
                    post.PostTitleImage = new byte[image.ContentLength];
                    image.InputStream.Read(post.PostTitleImage, 0, image.ContentLength);
                }
                _postService.Update(post, selectedTags);
                return RedirectToAction("Index");
            }
            PopulateAssignedPostTag(post);
            ViewBag.AuthorID = new SelectList(_authorService.GetAll(), "AuthorId", "AuthorName", post.AuthorId);
            return View(post);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _postService.Get(id.Value);

            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);


        }
     
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Post post)
        {


            if (post == null)
            {
                return HttpNotFound();
            }

            try
            {
                _postService.Delete(post);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Bağlantılı entity ler olduğundan silemezsiniz");
                return View(post);
            }

        }
        // GET: Admin/Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _postService.Get(id.Value);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        public FileContentResult GetImage(int postId)
        {
            Post post = _postService.Get(postId);

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
    }
}