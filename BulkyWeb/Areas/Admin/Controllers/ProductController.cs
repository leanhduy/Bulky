﻿using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

namespace BulkyWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		// Built-in service to access wwwroot directory
		// Since it is built-in, no need to inject inside Program.cs
		private readonly IWebHostEnvironment _webHostEnvironment;

		public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}

		#region CRUD
		// READ: ALL BOOKS
		public IActionResult Index()
		{
			List<Product> products = _unitOfWork.Products.GetAll(includeProps: "Category").ToList();
			return View(products);
		}

		public IActionResult Details(int id)
		{
			Product product = _unitOfWork.Products.Get(p => p.Id == id, includeProps: "Category");
			return View(product);
		}

		// CREATE + UPDATE: GET
		// Combine Create & Update operation into one single action
		public IActionResult Upsert(int? id)
		{
			// Apply EF Core: Projections to convert List of Categories to List of generic SelectListItem
			IEnumerable<SelectListItem> CategoryList = _unitOfWork.Categories.GetAll().Select(
				u => new SelectListItem
				{
					Text = u.Name,
					Value = u.ID.ToString()
				}
			);

			ProductVM vm = new ProductVM
			{
				CategoryList = CategoryList,
				Product = new Product()
			};
			// If id is not null, then it is an update scenario
			// Otherwise, it's a create scenario
			if (id != null && id > 0)
			{
				// Update
				vm.Product = _unitOfWork.Products.Get(p => p.Id == id);
			}
			return View(vm);
		}

		[HttpPost]
		public IActionResult Upsert(ProductVM vm, IFormFile? file)
		{

			if (ModelState.IsValid)
			{
				// Access the wwwroot
				string rootPth = _webHostEnvironment.WebRootPath;
				if (file != null)
				{
					// Create the new name of the uploaded file to be a unique GUID string
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					// Forming the file path
					string productPath = Path.Combine(rootPth, @"images\product");

					// Scenarios
					// #1: ImageUrl: not null ==> Delete old image, upload new image
					if (!string.IsNullOrEmpty(vm.Product.ImageUrl))
					{
						// delete old image
						var oldPath = Path.Combine(rootPth, vm.Product.ImageUrl.TrimStart('\\'));
						if (System.IO.File.Exists(oldPath))
						{
							System.IO.File.Delete(oldPath);
						}
					}

					// #2: ImageUrl: null ==> Upload new image
					// save the file
					using (var fs = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
					{
						file.CopyTo(fs);
					}

					// Save the file path into Product's ImageUrl
					vm.Product.ImageUrl = @$"\images\product\{fileName}";
				}

				// Differentiate Insert & Update case. When view model's product id = 0 => Insert case
				if (vm.Product.Id == 0)
				{
					_unitOfWork.Products.Insert(vm.Product);
				}
				else
				{
					_unitOfWork.Products.Update(vm.Product);
				}
				_unitOfWork.Save();
				TempData["success"] = $"Created Product: {vm.Product.Title} successfully!";
				return RedirectToAction("Index");
			}
			else
			{
				vm.CategoryList = _unitOfWork.Categories.GetAll().Select(
					c => new SelectListItem
					{
						Text = c.Name,
						Value = c.ID.ToString()
					}
				);
			}
			return View();
		}

		// DELETE : GET
		public IActionResult Delete(int? id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}
			Product? product = _unitOfWork.Products.Get(p => p.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		[HttpPost]
		public IActionResult DeletePOST(int? id)
		{
			Product? product = _unitOfWork.Products.Get(p => p.Id == id);
			if (product == null)
			{
				TempData["error"] = $"Error: Cannot delete this product!";
				return RedirectToAction("Index");
			}
			_unitOfWork.Products.Remove(product);
			_unitOfWork.Save();
			TempData["success"] = $"Update Product with ID {product.Id} successfully!";
			return RedirectToAction("Index");
		}
		#endregion

		#region API
		[HttpGet]
		// endpoint: /admin/product/getall
		public IActionResult GetAll()
		{
			var products = _unitOfWork.Products.GetAll(includeProps: "Category").ToList();
			return Json(new { data = products });
		}
		#endregion
	}
}
