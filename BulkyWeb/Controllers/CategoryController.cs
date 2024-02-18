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

		// CREATE
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
				TempData["success"] = "Category created successfully!";
				return RedirectToAction("Index");
			}
			return View();
		}

		// UPDATE
		// GET: 
		public IActionResult Edit(int? id)
		{
			// Check if id is null or valid
			if (id == null || id == 0)
			{
				return NotFound();
			}

			// Different LINQ approach to get data by id
			//Category? cate = _db.Categories.Where(c => c.ID == id);
			//Category? cate = _db.Categories.Find(id);
			Category? cate = _db.Categories.FirstOrDefault(c => c.ID == id);
			if (cate == null)
			{
				return NotFound();
			}
			return View(cate);
		}

		// POST: 
		[HttpPost]
		public IActionResult Edit(Category cate)
		{
			// Apply same custom validation as in CREATE
			// Custom validation: Name can't be same with DisplayedOrder
			if (cate.Name == cate.DisplayedOrder.ToString())
			{
				ModelState.AddModelError("name", "Name can not have same value with Displayed Order.");
			}
			// Server-side validation
			if (ModelState.IsValid)
			{
				_db.Categories.Update(cate);
				_db.SaveChanges();
				TempData["success"] = "Category updated successfully!";
				return RedirectToAction("Index");
			}
			return View();

		}

		// DELETE
		// GET: 
		public IActionResult Delete(int? id)
		{
			// Check if id is null or valid
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Category? cate = _db.Categories.FirstOrDefault(c => c.ID == id);
			if (cate == null)
			{
				return NotFound();
			}
			return View(cate);
		}

		// POST: 
		[HttpPost]
		public IActionResult DeletePOST(int? id)
		{
			// Find the category from the db
			Category? cateToBeDeleted = _db.Categories.FirstOrDefault(c => c.ID == id);
			if (cateToBeDeleted == null)
			{
				return NotFound();
			}

			_db.Categories.Remove(cateToBeDeleted);
			_db.SaveChanges();
			TempData["success"] = "Category deleted successfully!";
			return RedirectToAction("Index");
		}
	}
}
