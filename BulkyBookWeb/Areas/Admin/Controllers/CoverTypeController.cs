using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CoverTypeController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _UnitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {           
            if (ModelState.IsValid)
            {
                _UnitOfWork.CoverType.Add(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Cover type save successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            //var category = _db.Categories.Find(id);
            var CoverTypeFromDbFirst = _UnitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (CoverTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {           
            if (ModelState.IsValid)
            {
                _UnitOfWork.CoverType.Update(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Cover type edited successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            var coverType = _UnitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var DelCoverType = _UnitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (DelCoverType == null)
            {
                return NotFound();
            }
            _UnitOfWork.CoverType.Remove(DelCoverType);
            _UnitOfWork.Save();
            TempData["success"] = "Cover Type deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
