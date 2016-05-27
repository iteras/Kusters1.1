using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class PersonInDeal
    {
        [Key]
        public int PersonInDealId { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int DealId { get; set; }
        public virtual Deal Deal { get; set; }

        public bool IsSeller { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
       public DateTime Date { get; set; }
    }
}
