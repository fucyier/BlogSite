using Blog.Business.Abstract;
using Blog.Domain.Concrete;
using Blog.WebUI.Areas.Admin.Models.TagModels;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        private ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        // GET: Admin/Tags
        public ActionResult Index(int page = 1)
        {
            var tags = _tagService.GetAll();

            var tagModel = new TagsAdminListViewModel()
            {
                Tags = tags.Skip((page - 1) * 10).Take(10),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = 10,
                    TotalItems = tags.Count(),
                    TotalPageCount = (int)Math.Ceiling((decimal)tags.Count() / 10),
                },

            };
            return View(tagModel);
        }

        // GET: Admin/Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagService.Get(id.Value);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // GET: Admin/Tags/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/Authors/Create

      
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                
                _tagService.Add(tag);
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: Admin/Tags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagService.Get(id.Value);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Admin/Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
               
                _tagService.Update(tag);

                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Admin/Tag/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagService.Get(id.Value);

            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Tag tag)
        {


            if (tag == null)
            {
                return HttpNotFound();
            }

            try
            {
                _tagService.Delete(tag);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Bağlantılı post lar olduğundan silemezsiniz");
                return View(tag);
            }

        }
    }
}