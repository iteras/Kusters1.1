using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Product
    {
        [Key]
       public int ProductId { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

       //public int PretensionId { get; set; }
       public virtual List<Pretension> Pretensions { get; set; }

       //public int PictureId { get; set; }
        public virtual List<Picture> Pictures { get; set; }

       //public int DealId { get; set; }
       public virtual List<Deal> Deals { get; set; }

       //public int DescriptionId { get; set; }
       public virtual List<Description> Descriptions { get; set; }


        [MaxLength(128)]
       public string Title { get; set; }

        [MaxLength(1024)]
       public string Content { get; set; }

       public double Price { get; set; }

        [MaxLength(128)]
       public string TrackingCode { get; set; }

    }
}
