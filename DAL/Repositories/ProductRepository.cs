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
   public class ProductRepository : EFRepository<Product>, IProductRepository
    {
       public ProductRepository(IDbContext dbContext) : base(dbContext)
       {
       }

       public List<Product> GetAllProductsForPerson(int personId)
       {
           List<Product> products;
           products =
               DbSet.Where(a => a.PersonId == personId).OrderBy(o => o.Created).ToList();
           return products;
       }

       //public List<Person> GetThisPersonByPersonId(int personId)
       //{
       //   return  DbSet.Where(a => a.PersonId == personId).Select(a => a.Person).ToList();
       //}
    }
}
