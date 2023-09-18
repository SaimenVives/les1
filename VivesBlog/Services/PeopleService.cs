using System.Collections;
using VivesBlog.Core;

namespace VivesBlog.Services
{
    public class PeopleService
    {

        private readonly VivesBlogDbContext _dbContext;

        public PeopleService(VivesBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Person>
    }
}
