using Microsoft.EntityFrameworkCore;
using VivesBlog.Core;
using VivesBlog.Model;

namespace VivesBlog.Services
{
    public class ArticleService
    {
        private readonly VivesBlogDbContext _dbContext;

        public ArticleService(VivesBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //get list all articles
        public IList<Article> GetAll()
        {
            return _dbContext.Articles.Include(a => a.Author).ToList();
        }

        //get article by id with author
        public Article GetById(int id)
        {
            return _dbContext.Articles
                .Include(a => a.Author)
                .SingleOrDefault(a => a.Id == id);
        }

        //add article
        public void Add(Article article)
        {
            _dbContext.Articles.Add(article);

            _dbContext.SaveChanges();
        }

        //delete
        public void Delete(int id)
        {
            var dbArticle = _dbContext.Articles.SingleOrDefault(p => p.Id == id);

            _dbContext.Articles.Remove(dbArticle);

            _dbContext.SaveChanges();
        }

        public void Edit(Article article)
        {
			var dbArticle = _dbContext.Articles.SingleOrDefault(p => p.Id == article.Id);

			dbArticle.Title = article.Title;
			dbArticle.Description = article.Description;
			dbArticle.Content = article.Content;
			dbArticle.AuthorId = article.AuthorId;

			_dbContext.SaveChanges();
		}
    }
}
