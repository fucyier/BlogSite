using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.Domain.Concrete
{
   public class PostDetail
    {
      
        [Key, ForeignKey("Postof"), Column(Order = 0)]
        public int PostId { get; set; }
        public virtual Post Postof { get; set; }
        [Display(Name = "Makale İçerik")]
        [Required(ErrorMessage = "Lütfen Makale İçeriği Giriniz...")]
        public string PostText { get; set; }


    }
}
