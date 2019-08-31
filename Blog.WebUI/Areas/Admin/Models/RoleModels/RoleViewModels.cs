using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Areas.Admin.Models.RoleModels
{
    public class RoleViewModel
    {
        [Required]
        [Display(Name = "Rol Adı")]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
    }
}