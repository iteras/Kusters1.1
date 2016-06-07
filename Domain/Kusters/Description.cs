using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Description
    {
        [Key]
        public int DescriptionId { get; set; }

        [Display(Name = nameof(Resources.Domain.Products), ResourceType = typeof(Resources.Domain))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = nameof(Resources.Domain.Content), ResourceType = typeof(Resources.Domain))]
        [MaxLength(500, ErrorMessageResourceName = "LengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(3, ErrorMessageResourceName = "MinLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        public string Content { get; set; }
    }
}
