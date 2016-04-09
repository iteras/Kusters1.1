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

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

       public virtual List<DealInCampaign> DealInCampaign { get; set; }

       //public int PersonInDeal { get; set; }
       public virtual List<PersonInDeal> PersonsInDeal { get; set; }

        [MaxLength(32)]
       public string From { get; set; }
        [MaxLength(32)]
       public string Until { get; set; }
        
       public bool DealDone { get; set; }
    }
}
