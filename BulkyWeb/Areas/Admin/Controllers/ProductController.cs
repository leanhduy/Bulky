using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

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
