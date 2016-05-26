using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Product
    {
        [Key]
       public int ProductId { get; set; }

        [Display(Name = nameof(Resources.Domain.ProductOwner), ResourceType = typeof(Resources.Domain))]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }


        [Display(Name = nameof(Resources.Domain.Pretensions), ResourceType = typeof(Resources.Domain))]
        //public int PretensionId { get; set; }
        public virtual List<Pretension> Pretensions { get; set; }

        [Display(Name = nameof(Resources.Domain.Pictures), ResourceType = typeof(Resources.Domain))]
       //public int PictureId { get; set; }
        public virtual List<Picture> Pictures { get; set; }


        [Display(Name = nameof(Resources.Domain.Deals), ResourceType = typeof(Resources.Domain))]
        //public int DealId { get; set; }
        public virtual List<Deal> Deals { get; set; }

        [Display(Name = nameof(Resources.Domain.Descriptions), ResourceType = typeof(Resources.Domain))]
        //public int DescriptionId { get; set; }
        public virtual List<Description> Descriptions { get; set; }


        [MaxLength(128, ErrorMessageResourceName = "LengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(3, ErrorMessageResourceName = "MinLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.Title), ResourceType = typeof(Resources.Domain))]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessageResourceName = "LengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(3, ErrorMessageResourceName = "MinLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.Content), ResourceType = typeof(Resources.Domain))]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [MaxLength(1024, ErrorMessageResourceName = "LengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(3, ErrorMessageResourceName = "MinLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.Descriptions), ResourceType = typeof(Resources.Domain))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = nameof(Resources.Domain.Price), ResourceType = typeof(Resources.Domain))]
        [DataType(DataType.Currency)]
       public double Price { get; set; }

        [Display(Name = nameof(Resources.Domain.TrackingCode), ResourceType = typeof(Resources.Domain))]
        [MaxLength(256)]
       public string TrackingCode { get; set; }

        [Display(Name = nameof(Resources.Domain.Created ), ResourceType = typeof(Resources.Domain))]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

    }
}
