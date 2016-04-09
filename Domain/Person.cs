using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        //public int RoleId { get; set; }
        //public virtual Role Role { get; set; }

        //public int ChatId { get; set; }
        //public virtual List<Chat> Chats { get; set; }

        //public int PersonInChatId { get; set; }
        public virtual List<PersonInChat> PersonsInChat { get; set; }

        //public int PretensionId { get; set; }
        //public virtual List<Pretension> Pretensions { get; set; }

        //public int PersonInPretensionId { get; set; }
        public virtual List<PersonInPretension> PersonsInPretension { get; set; }

        //public int PictureId { get; set; }
        //public virtual List<Picture> Pictures { get; set; }

        //public int PersonInDealId { get; set; }
        public virtual List<PersonInDeal> PersonsInDeal { get; set; }

        //public int ProductId { get; set; }
        public virtual List<Product> Products { get; set; }

        //public int PersonInContractId { get; set; }
        public virtual List<PersonInContract>  PersonsInContract { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual UserInt User { get; set; }

        [MaxLength(32)]
        public string FirstName { get; set; }
        [MaxLength(32)]
        public string LastName { get; set; }

        public bool Sex { get; set; } //true male, false female
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(32)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string TelNr { get; set; }
        [MaxLength(64)]
        public string BankNr { get; set; }

        public bool Locked { get; set; } //true means locked, false means not locked
        public double Money { get; set; }
        public int Invited { get; set; } //is int proper type???
        public double Rating { get; set; }
    }
}
