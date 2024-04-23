using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class BankController : Controller
    {
        public BankController()
        {
        }

        public IActionResult Index()
        {
            BankContext bankContext = new BankContext();
            var context = bankContext.BankBranches.ToList();
            return View(context);
            //return View(BranchData.Branches);
        }
        public IActionResult Details(int id)
        {
            BankContext bankContext = new BankContext();
            var branches = bankContext.BankBranches.Include(r=> r.Employees).First(x => x.Id == id);


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
                BankContext bankContext = new BankContext();

                var branch = new BankBranch
                {
                    LocationName = form.LocationName,
                    BranchManager = form.BranchManager,
                    EmployeeCount = form.EmployeeCount,
                    LocationURL = form.LocationURL
                };
                //var locationName = form.LocationName;
                //var branchManager = form.BranchManager;
                //var employeeCount = form.EmployeeCount;
                //var locationURL = form.LocationURL;
                //BranchData.Branches.Add();
                //BranchData.Branches.Add(branch);
                bankContext.BankBranches.Add(branch);
                bankContext.SaveChanges();
                return RedirectToAction("Index", "Bank");
            }
            return View(form);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            BankContext bankContext = new BankContext();

            var branch = bankContext.BankBranches.Find(id);

            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }
        [HttpPost]
        public IActionResult Edit(int id, BankBranch branch)
        {
            BankContext bankContext = new BankContext();

            if (id != branch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bankContext.Update(branch);
                    bankContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankBranchExists(branch.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(branch);
        }
            private bool BankBranchExists(int id)
            {
            BankContext bankContext = new BankContext();

            return bankContext.BankBranches.Any(e => e.Id == id);
            }
        public IActionResult AddEmployee(int id)
        {

            //ViewBag.BranchId = id;
            return View();
               
        }
        [HttpPost]
        public IActionResult AddEmployee(int id, AddEmployeeForm employee)
        {
            if (ModelState.IsValid)
            {
                var database = new BankContext();
                var bankbranch = database.BankBranches.Find(id);
                var addEmployee = new Employee();

                addEmployee.Name = employee.Name;
                addEmployee.CivilId = employee.CivilId;
                addEmployee.Position = employee.Position;
                bankbranch.Employees.Add(addEmployee);
                database.SaveChanges();
                //using (var context = new BankContext())
                //{
                //var branch = context.BankBranches.Include(b => b.Employees).FirstOrDefault(b => b.Id == id);
                //if (branch == null)
                //{
                //    return NotFound();
                //}
                //employee.BankBranchId = id;
                //branch.Employees.AddRange(employee.Name, employee.CivilId, employee.Position);
                //context.SaveChanges();
                return RedirectToAction("Details", new { id = id });
            }
                    return View(employee);

            }
            //ViewBag.Id = id;
        }
        
        }
    
