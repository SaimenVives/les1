using VivesBlog.Core;
using VivesBlog.Model;

namespace VivesBlog.Services
{
    public class PeopleService
    {
        private readonly VivesBlogDbContext _dbContext;

        public PeopleService(VivesBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Person> GetAllPersons()
        {
            return _dbContext.People.ToList();
        }

        public void Create(Person person)
        {
            _dbContext.People.Add(person);
			_dbContext.SaveChanges();
		}

        public Person PersonById(int id)
        {
            return _dbContext.People.SingleOrDefault(p => p.Id == id);
        }

        public Person PersonByObjId(Person person)
        {
            return _dbContext.People.SingleOrDefault(p => p.Id == person.Id);
        }

        public void Delete(int id)
        {
            var dbPerson = _dbContext.People.SingleOrDefault(p => p.Id == id);

            _dbContext.People.Remove(dbPerson);

            _dbContext.SaveChanges();
        }

        public void Edit(Person person)
        {
			var dbPerson = PersonByObjId(person);

			dbPerson.FirstName = person.FirstName;
			dbPerson.LastName = person.LastName;

			_dbContext.SaveChanges();
		}

        public IList<Person> GetPersonsOrdered()
        {
			return _dbContext.People
				.OrderBy(a => a.FirstName)
				.ThenBy(a => a.LastName)
				.ToList();
		}
    }
}
