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

       public double Percentage { get; set; }
        [MaxLength(32)]
       public string From { get; set; }
        [MaxLength(32)]
        public string Until { get; set; }

    }
}
