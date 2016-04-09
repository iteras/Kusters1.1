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
    }
}
