using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Domain.Concrete;
using Blog.WebUI.Models;
using Blog.Business.Abstract;
using Blog.WebUI.Areas.Admin.Models;

using Blog.WebUI.Areas.Admin.Models.CommentModels;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private ICommentService _commentService;
        private IPostService _postService;
        public CommentController(ICommentService commentService,IPostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }

        // GET: Admin/Authors
        public ActionResult Index(int page = 1)
        {
            var comments = _commentService.GetAll();

            var commentModel = new CommentAdminListViewModel()
            {
                Comments = comments.Skip((page - 1) * 10).Take(10),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = 10,
                    TotalItems = comments.Count(),
                    TotalPageCount = (int)Math.Ceiling((decimal)comments.Count() / 10),
                },

            };
            return View(commentModel);
        }

        // GET: Admin/Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentService.Get(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Admin/Authors/Create
        public ActionResult Create()
        {
            var comment = _commentService.GetNewObject();
            ViewBag.PostId = new SelectList(_postService.GetAll().Where(x => x.PostStatus == true), "PostId", "PostTitle");
            return View(comment);
        }

        // POST: Admin/Authors/Create

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
              
                _commentService.Add(comment);
                return RedirectToAction("Index");
            }

            return View(comment);
        }

        // GET: Admin/Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentService.Get(id.Value);
            ViewBag.PostId = new SelectList(_postService.GetAll().Where(x => x.PostStatus == true), "PostId", "PostTitle", comment.PostId);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentService.Update(comment);

                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(_commentService.GetAll(), "PostId", "PostTitle", comment.PostId);
            return View(comment);
        }

      
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentService.Get(id.Value);

            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
           

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Comment comment)
        {

            if (comment == null)
            {
                return HttpNotFound();
            }
           
            try
            {
                _commentService.Delete(comment);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Bağlantılı post lar olduğundan silemezsiniz");
                return View(comment);
            }

        }

       
    }
}
