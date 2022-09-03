using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using patients.Models;
namespace Patients.Controllers;
public class OfficeController:Controller
{
   private readonly IOffice db;
   public OfficeController(IOffice _db)
   {
     db=_db;
   }
    public IActionResult adddroffice()
   {
    ViewBag.office=db.ShowOffice();
    // ViewBag.OfficeCount = db.ShowOffice().Count();
     menu.title="Add Dr.Office";
     return View();
   }
   
   public IActionResult addoffice( VmOffice off)
   {
    if(db.AddOffice(off))
    {
        return RedirectToAction("adddroffice");
    }
    return RedirectToAction("adddroffice");
    
   }
  
   public IActionResult updateoffice(int id)
   {
     menu.title="Edit Dr.Office";
     var result=db.GetOfficeById(id);
     return View(result);
   }
   public IActionResult editoffice( VmOffice of)
   {
     db.EditOffice(of);
     return RedirectToAction("adddroffice");
   }
  
   public IActionResult deloffice(int id)
   {
     db.DeleteOffice(id);
     return RedirectToAction("adddroffice");
   }
}