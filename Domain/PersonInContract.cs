using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class PersonInContract
    {
        [Key]
       public int PersonInContractId { get; set; }

        public int? PersonId { get; set; }
        public virtual Person Person { get; set; } //maybe should put in List?

        public int? ContractId { get; set; }
        public virtual Contract Contract { get; set; }

        [MaxLength(32)]
       public string From { get; set; }
        [MaxLength(32)]
        public string Until { get; set; }
    }
}
