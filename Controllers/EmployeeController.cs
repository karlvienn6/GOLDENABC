using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Goldenabc.Models;
using mysqlefcore;

namespace Goldenabc.Controllers;

public class EmployeeController : Controller
{   

    // private readonly DbContext
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context) {
        _context = context;
    }

    public IActionResult Index()
    {   

        ViewBag.employees = _context.Employee.ToList();
        Console.WriteLine(_context.Employee.ToList()[0].firstName+ "gago");
        return View();
    }

    [HttpPost]
    public IActionResult AddEmployee(Employee employee){
        if(ModelState.IsValid){
            _context.Employee?.Add(employee);
            _context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }
        return View(employee);
    }
    
    public IActionResult EditEmployee(int employeeId){
        ViewBag.Employee = _context.Employee.FirstOrDefault(emp => emp.employeeId == employeeId);
        Console.WriteLine("pareh");
        return Ok();
    }

    // [HttpPost]
    // public IActionResult EditEmployee(Branch branch){
        
    //     Console.WriteLine("pareh ko naman??");
    //     Console.WriteLine(branch.isActive+" negatibo");

    //     var editBranch = _context.Branch?.FirstOrDefault(b => b.branchCode == branch.branchCode);
    //     branch.isActive = editBranch?.isActive;

    //     if(editBranch == null){
    //         return NotFound();
    //     }

        

    //     editBranch.branchName = branch.branchName;
    //     editBranch.address = branch.address;
    //     editBranch.branchManager = branch.branchManager;
    //     editBranch.city = branch.city;
    //     editBranch.isActive = branch.isActive;
    //     editBranch.dateOpened = branch.dateOpened;
    //     editBranch.barangay = branch.barangay;

    //     _context.SaveChanges();

    //     return RedirectToAction("Index", "Branch");
    // }

    // [HttpPost]
    // public IActionResult DeleteBranch(string branchCode){
    //     var delete = _context.Branch?.Find(branchCode);
        
    //     if(delete != null){
    //         _context.Branch?.Remove(delete);
    //         _context.SaveChanges();
    //     }
    //     else{
    //     }


    //     return RedirectToAction("Index", "Branch");
    // }
}
