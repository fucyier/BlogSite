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
using Blog.WebUI.Areas.Admin.Models.AuthorModels;
using Microsoft.AspNet.Identity;
using Blog.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNet.Identity.EntityFramework;
using Blog.WebUI.Infrastructure;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class AuthorsController : Controller
    {
        private IAuthorService _authorService;
        public UserManager<ApplicationUser> UserManager { get; private set; }

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new BlogContext()));
        }

        // GET: Admin/Authors
        public ActionResult Index(int page = 1)
        {
            IEnumerable<Author> authors;
            if (User.Identity.IsAdmin())
            {
                authors = _authorService.GetAll();
            }
            else
            {
                authors = _authorService.GetAll().Where(x => x.UserId == User.Identity.GetUserId());
            }


            var authorModel = new AuthorsAdminListViewModel()
            {
                Authors = authors.Skip((page - 1) * 10).Take(10),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = 10,
                    TotalItems = authors.Count(),
                    TotalPageCount = (int)Math.Ceiling((decimal)authors.Count() / 10),
                },

            };
            Author a = _authorService.GetAll().Where(x => x.UserId == User.Identity.GetUserId()).FirstOrDefault();
            if (a != null)
            {
                if (a.AuthorStatus)
                {
                    ViewBag.IsAuthor = true;
                }
                else
                    ViewBag.IsAuthor = false;
            }
            else
            {
                ViewBag.IsAuthor = false;
            }

            return View(authorModel);
        }

        // GET: Admin/Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorService.Get(id.Value);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Admin/Authors/Create
        public ActionResult Create()
        {

            ViewBag.UserId = new SelectList(UserManager.Users.ToList(), "Id", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    author.ImageMimeType = image.ContentType;
                    author.AuthorPhoto = new byte[image.ContentLength];
                    image.InputStream.Read(author.AuthorPhoto, 0, image.ContentLength);
                }
                _authorService.Add(author);
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(UserManager.Users.ToList(), "Id", "UserName", author.UserId);
            return View(author);
        }

        // GET: Admin/Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorService.Get(id.Value);

            if (author == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(UserManager.Users.ToList(), "Id", "UserName", author.UserId);
            return View(author);
        }

        // POST: Admin/Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author author, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    author.ImageMimeType = image.ContentType;
                    author.AuthorPhoto = new byte[image.ContentLength];
                    image.InputStream.Read(author.AuthorPhoto, 0, image.ContentLength);
                }
                _authorService.Update(author);

                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(UserManager.Users.ToList(), "UserId", "UserName", author.UserId);
            return View(author);
        }

        // GET: Admin/Authors/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorService.Get(id.Value);

            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Author author)
        {


            if (author == null)
            {
                return HttpNotFound();
            }

            try
            {
                _authorService.Delete(author);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Bağlantılı post lar olduğundan silemezsiniz");
                return View(author);
            }

        }

        public FileContentResult GetImage(int AuthorId)
        {
            Author author = _authorService.Get(AuthorId);

            if (author != null)
            {
                if (author.AuthorPhoto != null && author.ImageMimeType != null)
                {
                    return File(author.AuthorPhoto, author.ImageMimeType);
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
