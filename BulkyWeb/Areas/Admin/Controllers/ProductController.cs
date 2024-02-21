using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private IUnitOfWork _unitOfWork;

		public ProductController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		#region CRUD
		// READ: ALL BOOKS
		public IActionResult Index()
		{
			List<Product> products = _unitOfWork.Products.GetAll().ToList();
			return View(products);
		}

		public IActionResult Details(int id)
		{
			Product product = _unitOfWork.Products.Get(p => p.Id == id);
			return View(product);
		}

		// CREATE : GET
		public IActionResult Create()
		{
			// Apply EF Core: Projections to convert List of Categories to List of generic SelectListItem
			IEnumerable<SelectListItem> CategoryList = _unitOfWork.Categories.GetAll().Select(
				u => new SelectListItem
				{
					Text = u.Name,
					Value = u.ID.ToString()
				}
			);

			// Pass the Category list to the view using ViewBag
			ViewBag.CategoryList = CategoryList;
			// Alternative #1: ViewData. e.g, ViewData["CategoryList"] = CategoryList
			// ViewData must be casted before usage (In view).
			// e.g asp-items = "@(ViewData["CategoryList"] as IEnumerable<SelectListItem)"
			// Alternative #2: TempData
			// Alternative #3: (recommended) ViewModel


			return View();
		}

		[HttpPost]
		public IActionResult Create(Product product)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Products.Insert(product);
				_unitOfWork.Save();
				TempData["success"] = $"Created Product: {product.Title} successfully!";
				return RedirectToAction("Index");
			}
			return View();
		}

		// EDIT : GET
		public IActionResult Edit(int? id)
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
			Category cate = _unitOfWork.Categories.Get(c => c.ID == product.CategoryId);
			ViewData["ProductCategory"] = cate.Name;
			ViewData["Categories"] = _unitOfWork.Categories.GetAll().ToList();
			return View(product);
		}

		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Products.Update(product);
				_unitOfWork.Save();
				TempData["success"] = $"Update Product with ID {product.Id} successfully!";
				return RedirectToAction("Index");
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

	}
}
