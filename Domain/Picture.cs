using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Picture
    {
        [Key]
        public int PictureId { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //public int PersonId { get; set; }
        //public virtual Person  Person { get; set; }


        [MaxLength(255)]
       public string Location { get; set; }
        [MaxLength(255)]
       public string Description { get; set; }
        [MaxLength(255)]
       public string Title { get; set; }
    }
}
