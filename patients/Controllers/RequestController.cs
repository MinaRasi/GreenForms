using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using patients.Models;
namespace Patients.Controllers;
public class RequestController : Controller
{
    private readonly IRequestForm db;
    private readonly IWebHostEnvironment env;
    public RequestController(IRequestForm _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
    }
    public IActionResult newformrequest()
    {
        menu.title = "New Form Request STEP 1/ 2";


        return View();
    }
    public IActionResult newformrequeststep2(VmRequestForm form)
    {
        menu.title = "New Form Request STEP 2/ 2";


        return View(form);
    }
    public IActionResult AddForm(VmRequestForm form)
    {
        if (form.Urlupload == null || db.AddForm(form) == null)

        {
            TempData["error"] = "Error";
            return RedirectToAction("newformrequest");
        }

        else
        {

            form.Lang = form.Lang.Remove(0, 1);
            var id = db.AddForm(form);
            HttpContext.Session.SetString("LastId", id.ToString());
        }
        return RedirectToAction("newformrequeststep2", form);
    }

    public IActionResult UpdateForm(VmRequestForm form)
    {
        if (HttpContext.Session.GetString("LastId") != null) ;
        {
            form.Id = Convert.ToInt32(HttpContext.Session.GetString("LastId"));

            if (db.UpdateForm(form) == form)
            {
                TempData["msg"] = "success";
                return RedirectToAction("newformrequest");
            }
        }
        return RedirectToAction("newformrequest");
    }
}