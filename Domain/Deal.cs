using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Deal
    {
        [Key]
       public int DealId { get; set; }

        //public int DealInContractId { get; set; }
        public virtual List<DealInContract>   DealsInContract { get; set; }

        //public int? CampaignId { get; set; }
        //public virtual Campaign Campaign { get; set; }

        [Display(Name = nameof(Resources.Domain.Products))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

       public virtual List<DealInCampaign> DealInCampaign { get; set; }

       //public int PersonInDeal { get; set; }
       public virtual List<PersonInDeal> PersonsInDeal { get; set; }

        [Display(Name = nameof(Resources.Domain.From), ResourceType = typeof(Resources.Domain))]
        [Required(ErrorMessageResourceName = "EmptyFieldError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [DataType(DataType.DateTime)]
        public DateTime From { get; set; }

        [Display(Name = nameof(Resources.Domain.Until), ResourceType = typeof(Resources.Domain))]
        [Required(ErrorMessageResourceName = "EmptyFieldError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [DataType(DataType.DateTime)]
        public DateTime Until { get; set; }
        
        [Display(Name = nameof(Resources.Domain.DealDone))]
       public bool DealDone { get; set; }
    }
}
