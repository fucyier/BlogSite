using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Domain.Concrete;

namespace Blog.WebUI.Models
{
    public class PostsListViewModel
    {
        public  IEnumerable<Post> Posts { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int? TagId { get; set; }
        public string TagText { get; set; }
        public int TotalPageCount { get; set; }
    }
}