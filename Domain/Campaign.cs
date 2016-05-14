using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Campaign
    {
        [Key]
       public int CampaignId { get; set; }

       //public int ContractId { get; set; }
       public virtual List<Contract> Contracts { get; set; }

       //public int DealId { get; set; }
       public virtual List<DealInCampaign> DealsInCampaign { get; set; }


        [Display(Name = nameof(Resources.Domain.Description), ResourceType = typeof(Resources.Domain))]
        [MinLength(3, ErrorMessageResourceName = "LengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MaxLength(2048)]
        public string Description { get; set; }

        [Display(Name = nameof(Resources.Domain.Percentage), ResourceType = typeof(Resources.Domain))]
        [Required(ErrorMessageResourceName = "EmptyFieldError", ErrorMessageResourceType = typeof(Resources.Domain))]
       public double Percentage { get; set; }

        [Display(Name = nameof(Resources.Domain.From), ResourceType = typeof(Resources.Domain))]
        [Required(ErrorMessageResourceName = "EmptyFieldError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [DataType(DataType.Date)]
        [MaxLength(32)]
       public string From { get; set; }

        [Display(Name = nameof(Resources.Domain.Until), ResourceType = typeof(Resources.Domain))]
        [Required(ErrorMessageResourceName = "EmptyFieldError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [DataType(DataType.Date)]
        [MaxLength(32)]
        public string Until { get; set; }

    }
}
