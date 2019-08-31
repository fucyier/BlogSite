using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Areas.Admin.Models.PostModels
{
    public class AssignedTagData
    {
        public int TagID { get; set; }
        public string TagName { get; set; }
        public bool Assigned { get; set; }
    }
}