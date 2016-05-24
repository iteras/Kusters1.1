using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace Dal.Interfaces
{
    public interface IDealRepository : IEFRepository<Deal>
    {
        List<Deal> GetAllDealsForPerson(int PersonId);
        List<Product> GetProductForDealByDealId(int? DealId);
    }
}
