using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
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

			ProductVM vm = new ProductVM
			{
				CategoryList = CategoryList,
				Product = new Product()
			};

			return View(vm);
		}

		[HttpPost]
		public IActionResult Create(ProductVM vm)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Products.Insert(vm.Product);
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
				return View(vm);
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
			IEnumerable<SelectListItem> categoryList = _unitOfWork.Categories.GetAll().Select(
					c => new SelectListItem
					{
						Text = c.Name,
						Value = c.ID.ToString()
					}
			);
			ProductVM vm = new ProductVM
			{
				Product = product,
				CategoryList = categoryList
			};
			return View(vm);
		}

		[HttpPost]
		public IActionResult Edit(ProductVM vm)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Products.Update(vm.Product);
				_unitOfWork.Save();
				TempData["success"] = $"Update Product with ID {vm.Product.Id} successfully!";
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
				return View(vm);
			}
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
