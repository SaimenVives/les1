using Microsoft.AspNetCore.Mvc;
using VivesBlog.Model;
using VivesBlog.Services;

namespace VivesBlog.Controllers
{
	public class PeopleController : Controller
	{
		private readonly PeopleService _peopleService;
		public PeopleController(PeopleService peopleService)
		{
			_peopleService = peopleService;
		}

		[HttpGet("People/Index")]
		public IActionResult Index()
		{
			var people = _peopleService.GetAllPersons();
			return View(people);
		}

		[HttpGet("People/Create")]
		public IActionResult PeopleCreate()
		{
			return View();
		}

		[HttpPost("People/Create")]
		public IActionResult PeopleCreate(Person person)
		{
			//uitzoeken
			//if (!ModelState.IsValid)
			//{
			//    return View(person);
			//}
			_peopleService.Create(person);

			return RedirectToAction("Index");
		}

		[HttpGet("People/Edit/{id}")]
		public IActionResult PeopleEdit(int id)
		{
			var person = _peopleService.PersonById(id);

			return View(person);
		}

		[HttpPost("People/Edit/{id}")]
		public IActionResult PeopleEdit(Person person)
		{
			//uitzoeken
			//if (!ModelState.IsValid)
			//{
			//    return View(person);
			//}

			_peopleService.Edit(person);

			return RedirectToAction("Index");
		}

		[HttpGet("People/Delete/{id}")]
		public IActionResult PeopleDelete(int id)
		{
			var person = _peopleService.PersonById(id);

			return View(person);
		}

		[HttpPost("People/Delete/{id}")]
		public IActionResult PeopleDeleteConfirmed(int id)
		{
			_peopleService.Delete(id);

			return RedirectToAction("Index");
		}
	}
}
