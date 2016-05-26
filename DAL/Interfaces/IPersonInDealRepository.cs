using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace Dal.Interfaces
{
    public interface IPersonInDealRepository : IEFRepository<PersonInDeal>
    {
        List<int> GetAllDealIDsForPerson(int personId);
        List<int> GetAllPersonsInDealByDealId(int dealId);
        List<int> GetAllPersonInDealIdsByDealId(int dealId);
        List<PersonInDeal> GetAllPersonInDealsByDealId(int dealId);
        Person GetBuyerInDealByDealId(int personInDealId, int personId);
        List<int> GetPersonInDealIdById(int personId);
        //List<string> GetPersonNameInDealByDealId(int dealId);
    }
}
