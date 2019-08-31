using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
   public class Post
   {
       public Post()
       {
           Comments = new List<Comment>();
           Tags = new List<Tag>();
           //Tags = new List<Tag>();
       }
        public int PostId { get; set; }

        [Display(Name = "Ana Başlık")]
        [Required(ErrorMessage = "Lütfen Ana Başlık Giriniz...")]
        public string PostTitle { get; set; }

       [Display(Name = "Kısa Başlık")]
       [Required(ErrorMessage = "Lütfen Kısa Başlık Giriniz...")]
        public string PostShortDetail { get; set; }

       [Display(Name = "Makale Tarih")]
       [DataType(DataType.Date)]
       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    
        public DateTime PostDate { get; set; }
        [Display(Name = "Makale Durumu")]
        public bool PostStatus { get; set; }
        [Display(Name = "Görüntülenme Sayısı")]
        public int ViewCount { get; set; }
        [Display(Name = "Resim")]
        public byte[] PostTitleImage { get; set; }
        public string ImageMimeType { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual PostDetail PostDetail { get; set; }
        [Display(Name = "Seçilmiş Makale")]
        public bool IsFeatured { get; set; }
        public string GenerateSlug()
        {
            string phrase = string.Format("{0}-{1}", PostId, PostTitle);

            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }
        private string RemoveAccent(string text)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
