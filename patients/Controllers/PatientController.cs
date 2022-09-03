using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using patients.Models;
namespace Patients.Controllers;
public class PatientController:Controller
{
    private readonly IPatient db;
    public PatientController(IPatient _db)
    {
        db=_db;
    }
    
    public IActionResult newpatient( )
    {
      menu.title="New Patient";
      return View();
    }
    public IActionResult addpatient(VmPatient p)
    {
       db.AddPatient(p);
       return RedirectToAction("newpatient");
    }

     public IActionResult PatientsInformation()
   {
    //  ViewBag.shopat=db.ShowPatient();
    //  menu.title="Patients Information"; 
     return View();
   }
}