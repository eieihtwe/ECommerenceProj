using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerenceProj.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return View(objCompanyList);
        }
        public IActionResult Create()
        {
            return View();
        }
       
        public IActionResult Upsert(int? id) //insert and update
        {
            if(id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company company = _unitOfWork.Company.Get(u => u.Id == id);
                return View(company);
            }           
        }
        [HttpPost]
        public IActionResult UpSert(Company companyObj)
        {
            if (ModelState.IsValid)
            {
                if(companyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(companyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(companyObj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Company Created successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(companyObj);
            }
        }
        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if(companyToBeDeleted == null){
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successfully." });
        }
        #endregion
    }
}
