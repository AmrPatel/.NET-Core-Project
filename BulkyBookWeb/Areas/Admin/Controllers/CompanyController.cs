using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //IEnumerable<Product> objCoverTypeList = _UnitOfWork.Product.GetAll();
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Company objComp = new();
            if (id == null || id == 0)
            {
                //Create Product
                return View(objComp);
            }
            else
            {
                objComp = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
                return View(objComp);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {

            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.Company.Add(obj);
                    TempData["success"] = "Company created successfully.";
                }
                else
                {
                    _unitOfWork.Company.Update(obj);
                    TempData["success"] = "Company updated successfully.";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Company.GetAll();
            return Json(new { data = companyList });

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var DelCompany = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            if (DelCompany == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            _unitOfWork.Company.Remove(DelCompany);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successfully." });
        }
        #endregion
    }
}
