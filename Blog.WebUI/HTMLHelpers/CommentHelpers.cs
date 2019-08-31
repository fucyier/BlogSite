using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.HTMLHelpers
{
    public static class CommentHelpers
    {
        public static MvcHtmlString CommentTree(this HtmlHelper html, IEnumerable<Blog.Domain.Concrete.Comment> comments)
        {
            StringBuilder result = new StringBuilder();

            result.Append(WriteTagHtml(comments.Where(c=>c.RootComment==null), null).ToString());
            return MvcHtmlString.Create(result.ToString());
        }
        //static TagBuilder tag = new TagBuilder("li");
        public static TagBuilder WriteTagHtml(IEnumerable<Comment> comments, Comment parentComment)
        {
            TagBuilder tag = new TagBuilder("li");
            
            foreach (Comment item in comments)
            {
                TagBuilder tagLi = new TagBuilder("li");
                tagLi.AddCssClass("media comment");

                TagBuilder tagImg = new TagBuilder("img");
                tagImg.MergeAttribute("src", "http://0.gravatar.com/avatar/ad516503a11cd5ca435acc9bb6523536?s=74");
                tagImg.MergeAttribute("width", "74");
                tagImg.MergeAttribute("height", "74");
                tagImg.AddCssClass("avatar media-object pull-left img-circle");

                TagBuilder tagDivBody = new TagBuilder("div");
                tagDivBody.AddCssClass("media-body");


                TagBuilder tagH4 = new TagBuilder("h4");
                tagH4.AddCssClass("media-heading author-vcard");

                TagBuilder tagCite = new TagBuilder("cite");
                tagCite.AddCssClass("fn");
                tagCite.InnerHtml = item.CommenterName;

                TagBuilder tagSpan = new TagBuilder("span");
                tagSpan.AddCssClass("comment-meta commentmetadata");
                tagSpan.InnerHtml = " on " + item.CommentDate;

                TagBuilder tagP = new TagBuilder("p");
                tagP.InnerHtml = item.Message;

                tagH4.InnerHtml = tagCite.ToString();
                tagH4.InnerHtml += tagSpan.ToString();

                tagDivBody.InnerHtml = tagH4.ToString();
                tagDivBody.InnerHtml += tagP.ToString();

                tagLi.InnerHtml = tagImg.ToString();
                tagLi.InnerHtml += tagDivBody.ToString();
                if (item.ChildComments.Count > 0)
                {
                    TagBuilder tagOl = new TagBuilder("ol");
                    tagOl.AddCssClass("media-list");
                    tagOl.InnerHtml = WriteTagHtml(item.ChildComments, item).ToString();
                    tagLi.InnerHtml += tagOl.ToString();

                }
                tag.InnerHtml += tagLi;
            }

            return tag;
        }

    }
}