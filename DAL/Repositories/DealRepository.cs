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

       public List<Deal> GetAllDealsForPerson(int personId)
       {
            //TODO: get all Deals for Sellers
            throw new NotImplementedException();
           // return DbSet.Where(a => a.PersonsInDeal
           //.Where(b => b.Person.PersonId == personId))
           //.ToList();
       }

       public List<Product> GetProductForDealByDealId(int? DealId)
       {
           List<Product> products = DbSet.Where(a => a.DealId == DealId).Select(a => a.Product).ToList();
           
           return products;
       }
    }
}
