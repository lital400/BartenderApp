using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BartenderApp.DataAccess.Repository;
using BartenderApp.DataAccess.Repository.IRepository;
using BartenderApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BartenderApp.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class CocktailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CocktailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Cocktail> cocktailtList = _unitOfWork.Cocktail.GetAll();
            return View(cocktailtList);
        }

        public IActionResult Order(int id)
        {
            // add to queue 
            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Cocktail.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Cocktail.Get(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting Cocktail";
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Cocktail.Remove(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "Category successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}
