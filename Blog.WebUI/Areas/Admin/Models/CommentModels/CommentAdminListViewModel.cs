using Blog.Domain.Concrete;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Areas.Admin.Models.CommentModels
{
    public class CommentAdminListViewModel
    {
            public IEnumerable<Comment> Comments { get; set; }
            public PagingInfo PagingInfo { get; set; }      
    }
}