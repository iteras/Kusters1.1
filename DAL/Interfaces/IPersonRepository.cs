using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace Dal.Interfaces
{
   public interface IPersonRepository : IEFRepository<Person>
   {
       List<Person> GetAllForUser(int userId);
       Person GetForUser(int personid, int userId);

       int GetPersonId(Person person);
   }

    
}
