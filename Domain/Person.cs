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

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "FirstnameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "FirstnameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.Firstname), ResourceType = typeof(Resources.Domain))]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "LastnameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "LastnameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.Lastname), ResourceType = typeof(Resources.Domain))]
        public string LastName { get; set; }

        [Display(Name = nameof(Resources.Domain.Registered), ResourceType = typeof(Resources.Domain))]
        [DataType(DataType.Date)]
        public DateTime Registered { get; set; }

        [Display(Name = nameof(Resources.Domain.Gender), ResourceType = typeof(Resources.Domain))]
        public bool Gender { get; set; } //true male, false female

        [Display(Name = nameof(Resources.Domain.Email), ResourceType = typeof(Resources.Domain))]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(32)]
        public string Password { get; set; }

        [Display(Name = nameof(Resources.Domain.TelNr), ResourceType = typeof(Resources.Domain))]
        [MaxLength(20)]
        public string TelNr { get; set; }
        [Display(Name = nameof(Resources.Domain.BankNr), ResourceType = typeof(Resources.Domain))]
        [MaxLength(64)]
        public string BankNr { get; set; }

        [Display(Name = nameof(Resources.Domain.Locked), ResourceType = typeof(Resources.Domain))]
        public bool Locked { get; set; } //true means locked, false means not locked

        [Display(Name = nameof(Resources.Domain.Money), ResourceType = typeof(Resources.Domain))]
        public double Money { get; set; }

        [Display(Name = nameof(Resources.Domain.Invited), ResourceType = typeof(Resources.Domain))]
        public int Invited { get; set; } //is int proper type???

        [Display(Name = nameof(Resources.Domain.Raiting), ResourceType = typeof(Resources.Domain))]
        public double Raiting { get; set; }


        [Display(Name = nameof(Resources.Domain.FirstLastname), ResourceType = typeof(Resources.Domain))]
        public string FirstLastName
        {
            get{ return FirstName + " " + LastName;}
        }


        
    }
}
