using Blog.Domain.Concrete;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Areas.Admin.Models.AuthorModels
{
    public class AuthorsAdminListViewModel
    {
            public IEnumerable<Author> Authors { get; set; }
            public PagingInfo PagingInfo { get; set; }      
    }
}