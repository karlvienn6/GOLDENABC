using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Goldenabc.Models;
using mysqlefcore;

namespace Goldenabc.Controllers;

public class BranchController : Controller
{   

    // private readonly DbContext
    private readonly AppDbContext _context;

    public BranchController(AppDbContext context) {
        _context = context;
    }

    public IActionResult BranchPage()
    {   
        return View();
    }

    public IActionResult Index()
    {
        var branches = _context.Branch?.ToList();
        ViewBag.branches = branches;
        return View();
    }

    public IActionResult AddBranchPage(){
        return View();
    }

    [HttpPost]
    public IActionResult AddBranchPage(Branch branch){
        if(ModelState.IsValid){
            branch.isActive = branch.isActive;
            _context.Branch?.Add(branch);
            _context.SaveChanges();

            return RedirectToAction("Index", "Branch");
        }
        return View(branch);
    }
    
    public IActionResult EditBranchPage(string branchCode){
        Console.WriteLine("wAtDaApAk");
        ViewBag.Branch = _context.Branch?.FirstOrDefault(b => b.branchCode == branchCode);

        return View();
    }

    [HttpPost]
    public IActionResult EditBranch(Branch branch){
        
        Console.WriteLine("pareh ko naman??");
        Console.WriteLine(branch.isActive+" negatibo");

        var editBranch = _context.Branch?.FirstOrDefault(b => b.branchCode == branch.branchCode);
        branch.isActive = editBranch?.isActive;

        if(editBranch == null){
            return NotFound();
        }

        

        editBranch.branchName = branch.branchName;
        editBranch.address = branch.address;
        editBranch.branchManager = branch.branchManager;
        editBranch.city = branch.city;
        editBranch.isActive = branch.isActive;
        editBranch.dateOpened = branch.dateOpened;
        editBranch.barangay = branch.barangay;

        _context.SaveChanges();

        return RedirectToAction("Index", "Branch");
    }

    [HttpPost]
    public IActionResult DeleteBranch(string branchCode){
        var delete = _context.Branch?.Find(branchCode);
        
        if(delete != null){
            _context.Branch?.Remove(delete);
            _context.SaveChanges();
        }
        else{
        }


        return RedirectToAction("Index", "Branch");
    }
}
