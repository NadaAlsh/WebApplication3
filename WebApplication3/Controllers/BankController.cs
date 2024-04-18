using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View(BranchData.Branches);
        }
        public IActionResult Details(int id)
        {
            var branches = BranchData.Branches.First(x => x.Id == id);


            if (branches == null)
            {
                return NotFound();
            }
            return View(branches);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewBranchForm form)
        {
            if (ModelState.IsValid)
            {
                var locationName = form.LocationName;
                var branchManager = form.BranchManager;
                var employeeCount = form.EmployeeCount;
                var locationURL = form.LocationURL;
                BranchData.Branches.Add(new BankBranch { LocationName = locationName, BranchManager = branchManager, EmployeeCount = employeeCount, LocationURL = locationURL });
                return RedirectToAction("Index", "Bank");

            }

            return View();
        }
    }
}