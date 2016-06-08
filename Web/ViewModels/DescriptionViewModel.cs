using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
   public class DescriptionViewModel
    {
       public int ProductId { get; set; }
       public Product Product { get; set; }

       public SelectList AllProducts { get; set; }
       public string Content { get; set; }
    }
}
