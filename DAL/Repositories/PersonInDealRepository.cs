using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace Dal.Repositories
{
   public class PersonInDealRepository : EFRepository<PersonInDeal>, IPersonInDealRepository
    {
       public PersonInDealRepository(IDbContext dbContext) : base(dbContext)
       {
       }

       public List<int> GetAllDealIDsForPerson(int personId)
       {
            
            return DbSet.Where(a => a.PersonId == personId).Select(a => a.DealId).ToList();
       }

       //public List<string> GetPersonNameInDealByDealId(int dealId)
       //{
       //    return DbSet.Where(a => a.DealId == dealId).Select( a => a.Person.FirstLastName).ToList();
       //}
    }
}
