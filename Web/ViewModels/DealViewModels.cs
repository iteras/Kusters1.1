using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
   public class DealViewModels
    {
       public int DealId { get; set; }
       public Deal Deal { get; set; }

       public List<Product> ProductList { get; set; }
    }
}
