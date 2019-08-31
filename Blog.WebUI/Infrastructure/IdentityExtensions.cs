using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using static Blog.WebUI.IdentityConfig;

namespace Blog.WebUI.Infrastructure
{
    public static class IdentityExtensions
    {
        public static string GetFullName(this IIdentity identity)
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userDetails = userManager.FindByIdAsync(currentUserId).Result;

            return String.Format("{0} {1}",userDetails!=null? userDetails.FirstName:string.Empty, userDetails != null ? userDetails.LastName:string.Empty);
        }
        public static IList<string> GetRoleName(this IIdentity identity)
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
           var roleList= userManager.GetRoles(currentUserId);
            return roleList;
        }

        public static bool IsAdmin(this IIdentity identity)
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
         
            HashSet<string> roleTags;
          
            if (!string.IsNullOrEmpty(currentUserId)&& userManager.FindById(currentUserId) != null)
            {
                roleTags = new HashSet<string>(userManager.GetRoles(currentUserId), StringComparer.OrdinalIgnoreCase);
               return roleTags.Contains("Admin") ? true : false;
            }
            return false;
        }
        public static bool IsUser(this IIdentity identity)
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            HashSet<string> roleTags;

            if (!string.IsNullOrEmpty(currentUserId) && userManager.FindById(currentUserId) != null)
            {
                roleTags = new HashSet<string>(userManager.GetRoles(currentUserId), StringComparer.OrdinalIgnoreCase);
                return roleTags.Contains("User") ? true : false;
            }
            return false;
        }
        public static bool IsAuthor(this IIdentity identity)
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            HashSet<string> roleTags;

            if (!string.IsNullOrEmpty(currentUserId) && userManager.FindById(currentUserId) != null)
            {
                roleTags = new HashSet<string>(userManager.GetRoles(currentUserId), StringComparer.OrdinalIgnoreCase);
                return roleTags.Contains("Author") ? true : false;
            }
            return false;
        }
        public static List<string> UserListwithRoleId(this IIdentity identity, string roleId)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
           var ds= userManager.Users.Include(c => c.Roles).Where(x => x.Roles.Select(r=>r.RoleId).Contains(roleId)).Select(c=>c.UserName).ToList();
            return ds;
        }
    }
}