using Hospital.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers;
[Area("Admin")]
public class UserController : Controller
{
    private IApplicationUserService _applicationUserService;

    public UserController(IApplicationUserService applicationUserService)
    {
        _applicationUserService = applicationUserService;
    }

    public IActionResult Index(int pageNumber = 1, int pageSize = 10)
    {
        return View(_applicationUserService.GetAll(pageNumber, pageSize));
    }

    public IActionResult AllDoctors(int pageNumber = 1, int pageSize = 10)
    {
        return View(_applicationUserService.GetAllDoctor(pageNumber, pageSize));
    }
}
