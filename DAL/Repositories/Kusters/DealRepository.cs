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
            List<int> asd = DbSet.Where(a => a.Product.PersonId == personId).Select(a => a.DealId).ToList(); //list of all this persons Deal
            List<Deal> allDealsForPerson = new List<Deal>();
           foreach (var item in asd)
           {
               allDealsForPerson.Add(DbSet.FirstOrDefault( a => a.DealId == item));
           }
           return allDealsForPerson;
           //List<PersonInDeal> allPersonInDealsForPerson = DbSet.Where(a => a.Product.)


       }

       public List<Product> GetProductForDealByDealId(int? DealId)
       {
           List<Product> products = DbSet.Where(a => a.DealId == DealId).Select(a => a.Product).ToList();
           
           return products;
       }
    }
}
