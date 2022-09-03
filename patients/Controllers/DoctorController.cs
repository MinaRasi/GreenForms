using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using patients.Models;
namespace Patients.Controllers;
public class DoctorController : Controller
{
    private readonly IDoctor db;

    public DoctorController(IDoctor _db)
    {
        db = _db;
    }

    //public IActionResult methodName()
    //{
    //TODO: Implement Realistic Implementation
    //if(adddoctor())
    //return View();
    // }
    public IActionResult adddoctor()
    {
        menu.title = "Add a new doctor";
        return View();
    }

    public IActionResult adddoci(VmDoctor doc)
    {
       
        if (db.AddDoctor (doc))
        {
            // opertation has been completed
             TempData["msg"]="Success";
             return RedirectToAction("adddoctor");     
        }

        // Error
        return View();
        
    }

    public IActionResult viewdoctor()
    {
        ViewBag.doctor1 = db.ShowDoctor();
        menu.title = "View Doctors";
        return View();
    }
    
    public IActionResult editdoctor(int id)
    {
       menu.title="Edit Doctor";
       var result =db.GetDoctorById(id);
       return View(result);
    }
    public IActionResult updatedoctor(VmDoctor doc)
    {
      db.EditDoctor(doc);
      return RedirectToAction("viewdoctor");
    }
    public IActionResult deldoctor(int id)
    {
      db.DeleteDoctor(id);
      return RedirectToAction("viewdoctor");
    }
}
