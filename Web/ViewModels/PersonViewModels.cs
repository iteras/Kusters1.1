using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Web.ViewModels
{
   public class PersonViewModels
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

       public enum Gender
       {
           Male = 0,
           Female = 1
       }
    }
}
