using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace Dal.Interfaces
{
    public interface IProductRepository : IEFRepository<Product>
    {
        List<Product> GetAllProductsForPerson(int personId);
        
    }
}