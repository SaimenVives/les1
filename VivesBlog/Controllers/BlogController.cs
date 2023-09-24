using Microsoft.AspNetCore.Mvc;
using System;
using VivesBlog.Model;
using VivesBlog.Services;
using VivesBlog.HelperClasses;
namespace VivesBlog.Controllers
{
	public class BlogController : Controller
	{
		private readonly ArticleService _articleService;
		private readonly ArticleModelHelper _articleModelHelper;
		public BlogController(ArticleService articleService, ArticleModelHelper articleModelHelper)
		{
			_articleService = articleService;
			_articleModelHelper = articleModelHelper;
		}

		[HttpGet("Blog/Index")]
		public IActionResult Index()
		{
			var articles = _articleService.GetAll();
			return View(articles);
		}

		[HttpGet("Blog/Create")]
		public IActionResult BlogCreate()
		{
			var articleModel = _articleModelHelper.CreateArticleModel();

			return View(articleModel);
		}

		[HttpPost("Blog/Create")]
		public IActionResult BlogCreate(Article article)
		{
			article.CreatedDate = DateTime.Now;

			_articleService.Add(article);

			return RedirectToAction("Index");
		}

		[HttpGet("Blog/Edit/{id}")]
		public IActionResult BlogEdit(int id)
		{
			var article = _articleService.GetById(id);

			var articleModel = _articleModelHelper.CreateArticleModel(article);

			return View(articleModel);
		}

		[HttpPost("Blog/Edit/{id}")]
		public IActionResult BlogEdit(Article article)
		{
			_articleService.Edit(article);

			return RedirectToAction("Index");
		}

		[HttpGet("Blog/Delete/{id}")]
		public IActionResult BlogDelete(int id)
		{
			var article = _articleService.GetById(id);

			return View(article);
		}

		[HttpPost("Blog/Delete/{id}")]
		public IActionResult BlogDeleteConfirmed(int id)
		{
			_articleService.Delete(id);

			return RedirectToAction("Index");
		}

	}
}
