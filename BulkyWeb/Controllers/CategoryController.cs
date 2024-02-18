using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Controllers
{

	// TODO: Convert data retrieving operation into async 

	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

		// Inject the DbContext into this Controller
		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			List<Category> categories = _db.Categories.ToList();
			return View(categories);
		}

		// GET: 
		public IActionResult Create()
		{
			return View();
		}

		// POST: 
		[HttpPost]
		public IActionResult CreatePOST()
		{
			return RedirectToAction("Index");
		}
	}
}
