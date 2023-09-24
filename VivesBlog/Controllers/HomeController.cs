using Microsoft.AspNetCore.Mvc;
using VivesBlog.Services;  

namespace VivesBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticleService _articleService;
        public HomeController(ArticleService articleService)
        {
            _articleService = articleService;
        }


        public IActionResult Index()
        {
            var articles = _articleService.GetAll();
            return View(articles);
        }

        public IActionResult ArticleDetails(int id)
        {
            var article = _articleService.GetById(id);

            return View(article);
        }
    }
}
