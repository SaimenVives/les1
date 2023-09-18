using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VivesBlog.Core;

namespace VivesBlog.Services
{
    public class ArticleService
    {

        private readonly VivesBlogDbContext _dbContext;

        public ArticleService(VivesBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Article> GetAll()
        {
            return _dbContext.Articles.Include(a => a.Author).ToList();
        }


    }
}
