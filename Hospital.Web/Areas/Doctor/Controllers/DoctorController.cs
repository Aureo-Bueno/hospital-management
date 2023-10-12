using Hospital.Models;
using Hospital.Services.Interfaces;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Hospital.Web.Areas.Doctor.Controllers;
[Area("Doctor")]
public class DoctorController : Controller
{
    private IDoctorService _doctorService;
    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public IActionResult AddTiming(int pageNumber=1, int pageSize=10)
    {
        return View(_doctorService.GetAll(pageNumber, pageSize));
    }

    [HttpGet]
    public IActionResult AddTiming()
    {
        Timing timing = new();
        List<SelectListItem> moningShiftStart = new();
        List<SelectListItem> moningShiftEnd = new();
        List<SelectListItem> afternoonShiftStart = new();
        List<SelectListItem> afternoonShiftEnd = new();

        for (int i = 1; i < 11; i++)
        {
            moningShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
        }
        for (int i = 0; i < 13; i++)
        {
            moningShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
        }
        for (int i = 13; i < 16; i++)
        {
            afternoonShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
        }
        for (int i = 13; i < 18; i++)
        {
            afternoonShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
        }

        @ViewBag.morningStart = new SelectList(moningShiftStart, "Value", "Text");
        @ViewBag.morningEnd = new SelectList(moningShiftEnd, "Value", "Text");
        @ViewBag.afternoonStart = new SelectList(afternoonShiftStart, "Value", "Text");
        @ViewBag.afternoonEnd = new SelectList(afternoonShiftEnd, "Value", "Text");
        TimingViewModel model = new();
        model.Date = DateTime.Now;
        model.Date = model.Date.AddDays(1);

        return View(model);
    }

    [HttpPost]
    public IActionResult AddTiming(TimingViewModel timingViewModel)
    {
        ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
        var claims = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        if (claims is not null)
        {
            timingViewModel.Doctor.Id = claims.Value;
            _doctorService.InsertTiming(timingViewModel);
        }
        _doctorService.InsertTiming(timingViewModel);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        return View(_doctorService.GetTimingById(id));
    }

    [HttpPost]
    public IActionResult Edit(TimingViewModel timingViewModel)
    {
        _doctorService.UpdateTimingInfo(timingViewModel);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(Guid id)
    {
        _doctorService.DeleteTiming(id);
        return RedirectToAction("Index");
    }
}
