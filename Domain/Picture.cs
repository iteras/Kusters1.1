    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Picture
    {
        [Key]
        public int PictureId { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //public int PersonId { get; set; }
        //public virtual Person  Person { get; set; }

       
        [MaxLength(255)]
       public string Location { get; set; }

        //[MaxLength(1024, ErrorMessageResourceName = "LengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        //[MinLength(3, ErrorMessageResourceName = "MinLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.PictureDescription))]
        [MaxLength(255)]
       public string Description { get; set; }

        [MaxLength(255, ErrorMessageResourceName = "LengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(3, ErrorMessageResourceName = "MinLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.Title))]
       public string Title { get; set; }
    }
}
