using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using patients.Models;

namespace Patients.Controllers;

public class HomeController : Controller
{
  private readonly IUser dbUser;
  private readonly IDoctor dbDoctor;
  public HomeController(IUser _dbUser,IDoctor _dbDoctor)
  {
    dbUser=_dbUser;
    dbDoctor=_dbDoctor;
  } 
    public IActionResult Index()
    {
      menu.title="Dashboard";
      ViewBag.UserCount=dbUser.GetUserCount();
      ViewBag.DoctorCount=dbDoctor.GetCount();
        return View();
    }
  
   public IActionResult importforms()
   {
     menu.title="Import Forms";
     return View();
   }
   public IActionResult saveasto()
   {
    menu.title="Save As To";
     return View();
   }

  
   public IActionResult addforms()
   {
     menu.title=" Add Form";
     return View();
   }
   public IActionResult adduser()
   {
     menu.title=" Add user";
     return View();
   }
   
 
   public IActionResult addquestions()
   {
     
     return View();
   }
   public IActionResult viewquestions()
   {
     menu.title="View questions";
     return View();
   }
   public IActionResult question1()
   {
     
     return View();
   }
   public IActionResult question2()
   {
    
     return View();
   }
   public IActionResult question3()
   {
     
     return View();
   }
}
