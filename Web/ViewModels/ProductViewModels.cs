using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
   public class ProductViewModels
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int ProductId { get; set; }
       public Product Product { get; set; }

        public SelectList AllPersons { get; set; }

        public List<Product> AllProducts { get; set; } 
        public List<Product> GetProductByPerson { get; set; }
    }
}
