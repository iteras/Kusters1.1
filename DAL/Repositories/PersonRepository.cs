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
    public class PersonRepository : EFRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<Person> GetAllForUser(int userId)
        {
            return DbSet.Where(p => p.UserId == userId).OrderBy(o => o.LastName).ThenBy(o => o.FirstName).ToList();
        }

        public Person GetForUser(int personId, int userId)
        {
            return DbSet.FirstOrDefault(a => a.PersonId == personId && a.UserId == userId);
        }

        public int GetPersonId(Person person)
        {
            return person.PersonId;
        }

        public Person GetPersonByFirstname(string firstName)
        {
            Person person = new Person();
            person = DbSet.FirstOrDefault(p => p.FirstName == firstName);
            return person;
            
        }
    }
}
