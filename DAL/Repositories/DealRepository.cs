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
using NLog.LayoutRenderers.Wrappers;

namespace Dal.Repositories
{
   public class DealRepository : EFRepository<Deal>, IDealRepository
    {
       public DealRepository(IDbContext dbContext) : base(dbContext)
       {
       }

       public List<Deal> GetAllDealsForPerson(int PersonId)
       {
           throw new NotImplementedException();
       }
    }
}
