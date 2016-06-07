using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class PersonInPretension
    {
        [Key]
        public int PersonInPretensionId { get; set; }

        public int? PretensionId { get; set; }
        public virtual Pretension Pretension { get; set; }

        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }

        [MaxLength(32)]
        public string From { get; set; }
        [MaxLength(32)]
        public string Until { get; set; }
    }
}
