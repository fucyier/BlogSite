using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
   public class Tag
   {
       public Tag()
       {
           Posts = new List<Post>();
       }
        public int TagId { get; set; }
        [Display(Name = "Konu Adı")]
        public string TagText { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}
