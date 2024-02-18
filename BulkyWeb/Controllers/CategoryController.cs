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
		public IActionResult Create(Category cate)
		{
			// Custom validation: Name can't be same with DisplayedOrder
			// Custom validation will be processed on server side (Page reloaded)
			if (cate.Name == cate.DisplayedOrder.ToString())
			{
				// The key ("name") is retrieved from the asp-for in the view (case-insensitive)
				ModelState.AddModelError("name", "Name can not have same value with Displayed Order.");
			}
			// Server-side validation
			if (ModelState.IsValid)
			{
				_db.Categories.Add(cate);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
