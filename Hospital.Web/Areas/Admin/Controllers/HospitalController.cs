using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers;
public class HospitalController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
