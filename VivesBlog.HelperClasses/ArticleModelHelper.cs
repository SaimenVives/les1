using VivesBlog.Model;
using VivesBlog.Services;

namespace VivesBlog.HelperClasses
{
	public class ArticleModelHelper
	{
		private readonly PeopleService _peopleService;
		public ArticleModelHelper(PeopleService peopleService)
		{
			_peopleService = peopleService;
		}

		public ArticleModel CreateArticleModel(Article article = null)
		{
			article ??= new Article();

			var authors = _peopleService.GetPersonsOrdered();

			var articleModel = new ArticleModel
			{
				Article = article,
				Authors = authors
			};

			return articleModel;
		}
	}
}