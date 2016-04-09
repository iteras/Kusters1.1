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

        public int? CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }

       //public int PersonInContractId { get; set; }
       public virtual List<PersonInContract> PersonsInContract { get; set; }

       //public int DealId { get; set; }
       //public virtual List<Deal> Deals { get; set; }

       public List<DealInContract> DealsInContract { get; set; }

        public string Content { get; set; }
        [MaxLength(128)]
       public string Title { get; set; }

    }
}
