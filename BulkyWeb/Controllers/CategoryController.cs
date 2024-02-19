﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repositories;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BulkyWeb.Controllers
{

	// TODO: Convert data retrieving operation into async 

	public class CategoryController : Controller
	{
		private readonly ICategoryRepository _repo;

		// Inject the DbContext into this Controller
		public CategoryController(ICategoryRepository repo)
		{
			_repo = repo;
		}

		public IActionResult Index()
		{
			List<Category> categories = _repo.GetAllCategories().ToList();
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
				_repo.InsertCategory(cate);
				_repo.Save();
				TempData["success"] = "Category created successfully!";
				return RedirectToAction("Index");
			}
			return View();
		}

		// UPDATE
		// GET: 
		public IActionResult Edit(int id)
		{
			// Check if id is null or valid
			if (id == 0)
			{
				return NotFound();
			}

			// Different LINQ approach to get data by id
			//Category? cate = _db.Categories.Where(c => c.ID == id);
			//Category? cate = _db.Categories.Find(id);
			Category? cate = _repo.GetCategoryById(id);
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
				_repo.UpdateCategory(cate);
				_repo.Save();
				TempData["success"] = "Category updated successfully!";
				return RedirectToAction("Index");
			}
			return View();

		}

		// DELETE
		// GET: 
		public IActionResult Delete(int id)
		{
			// Check if id is null or valid
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Category? cate = _repo.GetCategoryById(id);
			if (cate == null)
			{
				return NotFound();
			}
			return View(cate);
		}

		// POST: 
		[HttpPost]
		public IActionResult DeletePOST(int id)
		{
			// Find the category from the db
			Category? cateToBeDeleted = _repo.GetCategoryById(id);
			if (cateToBeDeleted == null)
			{
				return NotFound();
			}

			_repo.DeleteCategory(id);
			_repo.Save();
			TempData["success"] = "Category deleted successfully!";
			return RedirectToAction("Index");
		}
	}
}
