using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
   public class Comment
    {
        public int CommentId { get; set; }
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "Lütfen E-Posta Giriniz...")]
        public string CommenterMail { get; set; }
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen Ad Soyad Giriniz...")]
        public string CommenterName { get; set; }
        [Display(Name = "Yorum")]
        [Required(ErrorMessage = "Message must be entered...")]
        public string Message { get; set; }
        [Display(Name = "Tarih")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CommentDate { get; set; }
        [Required(ErrorMessage = "Post Id...")]
        public int PostId { get; set; }
        public Post Post { get; set; }
        [Display(Name = "Durum")]
        public bool Status { get; set; }

        public int? RootId { get; set; }
        public Comment RootComment { get; set; }
        public virtual List<Comment> ChildComments { get; set; }
    }
}
