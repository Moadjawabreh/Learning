using Learning.DataAccess.Repository.IRepository;
using Learning.DataAccess.Data;
using Learning.Models;
using Microsoft.AspNetCore.Mvc;
using Learning.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Learning.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IUnitOfWork _unitOfWork,IWebHostEnvironment _webHostEnvironment)
        {
            unitOfWork = _unitOfWork;
			webHostEnvironment= _webHostEnvironment;

		}
        public IActionResult Index()
        {
            List<Product> Products = unitOfWork.productRepository.GetAll().ToList();
            return View(Products);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
           
                if (product.ImageFile != null)
                {
                    string wwwRootPath = webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "" +
                    product.ImageFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        product.ImageFile.CopyTo(fileStream);
                    }
                    product.imageUrl = fileName;

				if (ModelState.IsValid)
				{
					TempData["success"] = "Success Created";
					unitOfWork.productRepository.Add(product);
					unitOfWork.Save();
					return RedirectToAction("Index");
				}
				
                }

           
            
			return View();
		}

		public IActionResult Edit(int? ProductId)
        {
            if (ProductId == null)
            {
                return NotFound();
            }
            Product? product = unitOfWork.productRepository.Get(ca => ca.Id == ProductId);
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
                TempData["success"] = "Success Edit";
                unitOfWork.productRepository.Update(product);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? ProductId)
        {
            if (ProductId == null)
            {
                return NotFound();
            }
            Product? product = unitOfWork.productRepository.Get(ca => ca.Id == ProductId);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(Product product)
        {
            TempData["success"] = "Success Delete";
            unitOfWork.productRepository.Delete(product);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}