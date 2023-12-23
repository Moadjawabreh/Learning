using Learning.DataAccess.Repository.IRepository;
using Learning.DataAccess.Data;
using Learning.Models;
using Microsoft.AspNetCore.Mvc;
using Learning.DataAccess.Repository;

namespace Learning.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CategController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IActionResult Index()
        {
            List<Categ> categs = unitOfWork.categRepsitory.GetAll().ToList();
            return View(categs);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categ categ)
        {
            if (categ.Name != null && categ.Name.ToLower() == "test")
            {
                ModelState.AddModelError("name", "the test is not Valid Value");
            }

			if (categ.Description != null && categ.Description.ToLower() == "test")
			{
				ModelState.AddModelError("Description", "the test is not Valid Value");
			}

			if (categ.Name != null && categ.Description != null && categ.Name.ToLower() == categ.Description.ToLower())
            {
                ModelState.AddModelError("name", "Name connot match the Description");
            }
            if (ModelState.IsValid)
            {
                TempData["success"] = "Success Created";
                unitOfWork.categRepsitory.Add(categ);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? CategId)
        {
            if (CategId == null)
            {
                return NotFound();
            }
            Categ? categ = unitOfWork.categRepsitory.Get(ca => ca.Id == CategId);
            if (categ == null)
            {
                return NotFound();
            }
            return View(categ);
        }

        [HttpPost]
        public IActionResult Edit(Categ categ)
        {
            if (categ.Name != null && categ.Name.ToLower() == "test")
            {
                ModelState.AddModelError("name", "the test is not Valid Value");
            }
            if (categ.Name != null && categ.Description != null && categ.Name.ToLower() == categ.Description.ToLower())
            {
                ModelState.AddModelError("name", "Name connot match the Description");
            }
            if (ModelState.IsValid)
            {
                TempData["success"] = "Success Edit";
                unitOfWork.categRepsitory.Update(categ);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? CategId)
        {
            if (CategId == null)
            {
                return NotFound();
            }
            Categ? categ = unitOfWork.categRepsitory.Get(ca => ca.Id == CategId);
            if (categ == null)
            {
                return NotFound();
            }
            return View(categ);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(Categ categ)
        {
            TempData["success"] = "Success Delete";
            unitOfWork.categRepsitory.Delete(categ);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}