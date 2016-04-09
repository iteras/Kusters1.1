using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class ChatInPretension
    {
        [Key]
        public int ChatInPretensionId { get; set; }

       public int? ChatId { get; set; }
       public virtual Chat Chat { get; set; }

       public int? PretensionId { get; set; }
       public virtual Pretension Pretension { get; set; }

    }
}
