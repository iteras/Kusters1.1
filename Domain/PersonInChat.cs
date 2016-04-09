using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public  class PersonInChat
    {
        [Key]
        public int PersonInChatId { get; set; }

        public int? ChatId { get; set; }
        public virtual Chat Chat { get; set; } //singularity is right? Shouldn't it be List?
                                               //Cuz person can be in multible chats

        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }

        public string Time { get; set; } //is it really needed if table "Chat" already contains Timestamp???
    }
}
