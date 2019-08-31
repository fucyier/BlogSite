using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
   public class Author
    {
        public int AuthorId { get; set; }
        [Display(Name = "Yazar Adı")]
        [Required(ErrorMessage = "Lütfen Yazar Adı Giriniz...")]
        public string AuthorName { get; set; }
        [Display(Name = "Yazar E-Posta")]
        [Required(ErrorMessage = "Lütfen Yazar E-Posta Giriniz...")]
        public string AuthorMail { get; set; }
        [Display(Name = "Oluşturma Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
      
        public DateTime AuthorCreationDate { get; set; }
        [Display(Name = "Yazar Bilgi")]
        [Required(ErrorMessage = "Lütfen Yazar Bilgi Giriniz...")]
        public string AuthorInfo { get; set; }
        [Display(Name = "Fotoğraf")]
        public byte[] AuthorPhoto { get; set; }
        [Display(Name = "Yazarlık Durumu")]
        public bool AuthorStatus { get; set; }
        public List<Post> Posts { get; set; }
        public string ImageMimeType { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
