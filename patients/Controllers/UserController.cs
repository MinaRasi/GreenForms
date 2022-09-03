using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using patients.Models;
namespace Patients.Controllers;
public class UserController : Controller
{
    private readonly IUser dbUser;
    public UserController(IUser _dbUser)
    {
       dbUser=_dbUser; 
    }
    public IActionResult adduser()
   {
     menu.title=" Add user";
     return View();
   }
   public IActionResult addus(VmUser m)
   {
     if (dbUser.adduser(m))
     {
       TempData["msg"] = "success";
       return RedirectToAction("adduser");
     }
     else 
     {
       TempData["error"] = "Error";
       return RedirectToAction("adduser");
     }
     
   }

   public IActionResult viewuser()
   {
     menu.title=" View user";
    ViewBag.userlist=dbUser.Showuser();
     return View();
   }
   public IActionResult del(int id)
   {
     dbUser.Deluser(id);
     return RedirectToAction("viewuser");
   }
   public IActionResult Update(int id)
   {
     menu.title=" Edit this user";
     var q= dbUser.GetId(id);
     return View(q);
   }
   public IActionResult edit(VmUser m)
   {
     dbUser.EditUser(m);
     return RedirectToAction("viewuser");
   }
   public IActionResult active(int id)
   {
     dbUser.ActiveUser(id);
     return RedirectToAction("viewuser");
   }
  


}