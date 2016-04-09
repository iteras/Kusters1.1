using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Description
    {
        [Key]
        public int DescriptionId { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
       
        [MaxLength(255)]
        public string Content { get; set; }
    }
}
