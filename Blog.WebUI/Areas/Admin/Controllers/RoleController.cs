using Blog.DataAccess.Concrete.EntityFramework;
using Blog.WebUI.Areas.Admin.Models.RoleModels;
using Blog.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        public RoleController()
           : this(new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new BlogContext())))
        { }

        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var roles = RoleManager.Roles.ToList();

            var roleModel = new RoleAdminListViewModel()
            {
                Roles = roles.Skip((page - 1) * 10).Take(10),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = 10,
                    TotalItems = roles.Count(),
                    TotalPageCount = (int)Math.Ceiling((decimal)roles.Count() / 10),
                },

            };
            return View(roleModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole() { Name = model.RoleName };
                var result = RoleManager.Create(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrors(result);
                }
            }
            return View(model);

        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var role = RoleManager.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(new RoleViewModel() { RoleId = role.Id, RoleName = role.Name });
        }

        // POST: Admin/Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = RoleManager.FindById(model.RoleId);
                role.Name = model.RoleName;

                var result = RoleManager.Update(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrors(result);
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = RoleManager.FindById(id);

            if (role == null)
            {
                return HttpNotFound();
            }
            return View(new RoleViewModel() { RoleId = role.Id, RoleName = role.Name });


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RoleViewModel model)
        {
            if (model == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {

                var role = RoleManager.FindById(model.RoleId);
                var result = RoleManager.Delete(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrors(result);
                }

            }
            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}