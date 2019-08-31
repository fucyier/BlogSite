using Blog.DataAccess.Concrete.EntityFramework;
using Blog.Domain.Concrete;
using Blog.WebUI.Areas.Admin.Models.AccountModels;
using Blog.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Blog.WebUI.Infrastructure;
using Blog.Business.Abstract;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {


        public AccountController(IAuthorService authorService)
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new BlogContext())), 
                  new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new BlogContext())))
        {
            _authorService = authorService;
        }
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        private IAuthorService _authorService;
        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
          
        }



        //
        // GET: /Account/Login
        [AllowAnonymous]

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToAction("Index", "Post");
                    // return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            IEnumerable<ApplicationUser> users;
            if (User.Identity.IsAdmin())
            {
                users = UserManager.Users.Include(c => c.Roles).ToList();
            }
            else
            {
                string userId = User.Identity.GetUserId();
                users = UserManager.Users.Include(c => c.Roles).Where(x => x.Id == userId).ToList();
            }


            var usersModel = new AccountsAdminListViewModel()
            {
                Users = users.Skip((page - 1) * 10).Take(10),

                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = 10,
                    TotalItems = users.Count(),
                    TotalPageCount = (int)Math.Ceiling((decimal)users.Count() / 10),
                },

            };
          
            return View(usersModel);
        }
        private void PopulateAssignedRolesTag(ApplicationUser user)
        {
            var allRoles = RoleManager.Roles.ToList();
            var roleTags = new HashSet<string>();
            if (UserManager.FindById(user.Id) != null)
            {
                roleTags = new HashSet<string>(UserManager.GetRoles(user.Id));
            }


            //    var roleTags = new HashSet<string>(user.Roles.Select(c => c.RoleId));
            var assignedRoleData = new List<AssignedRoleData>();
            foreach (var tag in allRoles)
            {
                assignedRoleData.Add(new AssignedRoleData
                {
                    RoleID = tag.Id,
                    RoleName = tag.Name,
                    Assigned = roleTags.Contains(tag.Name)
                });
            }
            ViewBag.Tags = assignedRoleData;
        }

        [AllowAnonymous]
        public ActionResult Register()
        {

            var user = new ApplicationUser();
            var model = new RegisterViewModel() { ApplicationUser = user };
            PopulateAssignedRolesTag(user);

            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, string[] selectedRoles)
        {

            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.EMail,
                PhoneNumber = model.PhoneNumber
            };

            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (selectedRoles != null)
                {
                    foreach (var roleId in selectedRoles)
                    {
                        var role = RoleManager.FindById(roleId);
                        if (!string.IsNullOrEmpty(role.Name))
                        {
                            var result2 = UserManager.AddToRole(user.Id, role.Name);
                        }

                    }
                }

                await SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Account");
            }
            AddErrors(result);
            PopulateAssignedRolesTag(user);
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = UserManager.FindById(id);
            // PopulateAssignedRolesTag(user);
            var model = new EditViewModel() { ApplicationUser = user };

            if (user == null)
            {
                return HttpNotFound();
            }
            PopulateAssignedRolesTag(user);
            TempData["Id"] = id;
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditViewModel editViewModel, string[] selectedRoles)
        {
            if (string.IsNullOrEmpty(TempData["Id"].ToString()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = UserManager.FindById(TempData["Id"].ToString());
            user.PhoneNumber = editViewModel.ApplicationUser.PhoneNumber;
            user.Email = editViewModel.ApplicationUser.Email;
            user.FirstName = editViewModel.ApplicationUser.FirstName;
            user.LastName = editViewModel.ApplicationUser.LastName;
            var result = await UserManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (UserManager.GetRoles(user.Id).Count > 0)
                {
                    foreach (var item in UserManager.GetRoles(user.Id))
                    {
                        var role = RoleManager.FindByName(item);
                        if (selectedRoles!=null && !selectedRoles.Contains(role.Id))
                        {
                            var result2 = UserManager.RemoveFromRole(user.Id, role.Name);
                            if ( role.Name.Contains("Author"))
                            {
                                _authorService.EditStatus(user.Id, false);
                            }
                        }
                    }
                }
                if (selectedRoles != null)
                {
                    foreach (var roleId in selectedRoles)
                    {
                        var role = RoleManager.FindById(roleId);
                        if (!string.IsNullOrEmpty(role.Name))
                        {
                            if (!UserManager.IsInRole(user.Id, role.Name))
                            {
                                var result2 = UserManager.AddToRole(user.Id, role.Name);
                            }
                            if (role.Name.Contains("Author"))
                            {
                                _authorService.EditStatus(user.Id, true);
                            }

                        }
                    }
                }


                // await SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Account");
            }

            AddErrors(result);



            PopulateAssignedRolesTag(editViewModel.ApplicationUser);
            return View(editViewModel);
        }
        //
        // POST: /Account/Disassociate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            ManageMessageId? message = null;
            IdentityResult result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                // User does not have a password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var user = await UserManager.FindAsync(loginInfo.Login);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // If the user does not have an account, then prompt the user to create an account
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = loginInfo.DefaultUserName });
            }
        }

        //
        // POST: /Account/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, Url.Action("LinkLoginCallback", "Account"), User.Identity.GetUserId());
        }

        //
        // GET: /Account/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            if (result.Succeeded)
            {
                return RedirectToAction("Manage");
            }
            return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Nav", new { area = "" });
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }
        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

    }
}