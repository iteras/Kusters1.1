using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Chat
    {
        [Key]
        public int ChatId { get; set; }

        //public int RoleId { get; set; }
        //public virtual Role Role { get; set; }

        //public int PersonId { get; set; }
        //public virtual Person Person { get; set; }

       //public int PersonInChatId { get; set; }
       public virtual List<PersonInChat> PersonsInChat { get; set; }
       public virtual List<ChatInPretension>    ChatsInPretension { get; set; }
       

        //public int PretensionId { get; set; }
        //public virtual Pretension Pretension { get; set; }

        [MaxLength(255)]
       public string Message { get; set; }


        [MaxLength(32)]
        [DataType(DataType.DateTime)]
       public string DateTime { get; set; }


    }
}
