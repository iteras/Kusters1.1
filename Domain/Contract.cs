using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Contract
    {
        [Key]
       public int ContractId { get; set; }
        [Display(Name = nameof(Resources.Domain.Campaigns), ResourceType = typeof(Resources.Domain))]

        public int CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }

       //public int PersonInContractId { get; set; }
       public virtual List<PersonInContract> PersonsInContract { get; set; }

       //public int DealId { get; set; }
       //public virtual List<Deal> Deals { get; set; }

       public List<DealInContract> DealsInContract { get; set; }

        [Display(Name = nameof(Resources.Domain.Content), ResourceType = typeof(Resources.Domain))]

        [MaxLength(3500, ErrorMessageResourceName="TooLongError", ErrorMessageResourceType = typeof(Resources.Domain))]
        public string Content { get; set; }

        [Display(Name = nameof(Resources.Domain.Title), ResourceType = typeof(Resources.Domain))]
        [MaxLength(128)]
       public string Title { get; set; }

    }
}
