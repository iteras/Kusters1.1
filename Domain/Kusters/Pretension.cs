using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Pretension
    {
        [Key]
        public int PretensionId { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //public int PersonId { get; set; }
        //public virtual Person Person { get; set; }

       //public int ChatId { get; set; }
       //public virtual List<Chat> Chats { get; set; }

       public virtual List<ChatInPretension> ChatsInPretension { get; set; }

       //public int PersonInPretensionId { get; set; }
       public virtual List<PersonInPretension> PersonsInPretension { get; set; }

        [MaxLength(255)]
       public string Content { get; set; }
        [MaxLength(255)]
       public string Title { get; set; }
    }
}
