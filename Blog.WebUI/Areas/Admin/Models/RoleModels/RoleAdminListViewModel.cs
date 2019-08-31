using Blog.WebUI.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Areas.Admin.Models.RoleModels
{
    public class RoleAdminListViewModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}