using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using patients.Models;
namespace Patients.Controllers;
public class FormController : Controller
{
     private readonly IDoctor db;

    public FormController(IDoctor _db)
    {
        db = _db;
    }
    public IActionResult addforms()
    {
        menu.title = " Add Form";
        ViewBag.list=db.ShowDoctor();
        ViewBag.Select=new SelectList(ViewBag.list,"Id","Lastname");
        return View();
    }

}
