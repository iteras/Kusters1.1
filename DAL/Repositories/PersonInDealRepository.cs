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
using Domain.Identity;


namespace Dal.Repositories
{
    public class PersonInDealRepository : EFRepository<PersonInDeal>, IPersonInDealRepository
    {
        public PersonInDealRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<int> GetAllDealIDsForPerson(int personId)
        {

            return DbSet.Where(a => a.PersonId == personId ).Select(a => a.DealId).ToList();
        }

        public List<int> GetAllPersonsInDealByDealId(int dealId)
        {
            List<int> personsInDeal = DbSet.Where(a => a.DealId == dealId).Select(a => a.PersonId).ToList();
            return personsInDeal;
        }

        public List<int> GetAllPersonInDealIdsByDealId(int dealId)
        {
            return DbSet.Where(a => a.DealId == dealId).Select(a => a.PersonInDealId).ToList();
        }

        public List<PersonInDeal> GetAllPersonInDealsByDealId(int dealId)
        {
            return DbSet.Where(a => a.DealId == dealId).ToList();
        }

        public Person GetBuyerInDealByDealId(int dealId, int personId) //TODO personInDeal must be replaced with DealId
        {
            List<Person> personsInDeal =
                DbSet.Where(a => a.DealId == dealId).Select(a => a.Person).ToList();
            Person person = new Person();
            foreach (var item in personsInDeal)
            {
                if (item.PersonId != personId) //if not seller then it must be buyer's id
                {
                    person = item;
                }
            }
            return person;
        }

        public List<int> GetPersonInDealIdById(int personId)
        {
            return DbSet.Where(a => a.PersonId == personId).Select(a => a.PersonInDealId).ToList();
        }
    }
}
  
