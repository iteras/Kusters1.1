using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class DealInContract
    {
        [Key]
       public int DealInContractId { get; set; }

       public int? DealId { get; set; }
       public virtual Deal Deal { get; set; }

       public int? ContractId { get; set; }
       public virtual Contract Contract { get; set; }
    }
}
