using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class DealInCampaign
   {
        [Key]
       public int DealInCampaignId { get; set; }

       public int? DealId { get; set; }
       public virtual int Deal { get; set; }

       public int? CampaignId { get; set; }
       public virtual int Campaign { get; set; }
            

   }
}
