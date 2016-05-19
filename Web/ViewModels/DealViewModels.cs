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

        public int ProductId { get; set; }
       public List<Product> ProductList { get; set; }
        public string PersonFirstName { get; set; }

        public Person Person { get; set; }
        public int PersonId { get; set; }
        public List<Person> PersonsList { get; set; } 
    }
}
