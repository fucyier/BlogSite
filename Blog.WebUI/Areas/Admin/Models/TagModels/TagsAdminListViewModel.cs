using Blog.Domain.Concrete;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Areas.Admin.Models.TagModels
{
    public class TagsAdminListViewModel
    {
            public IEnumerable<Tag> Tags { get; set; }
            public PagingInfo PagingInfo { get; set; }
    }
}