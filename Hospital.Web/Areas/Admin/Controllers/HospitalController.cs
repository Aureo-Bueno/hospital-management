using Hospital.Services.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers;
[Area("admin")]
public class HospitalController : Controller
{
    private IHospitalInfo _hospitalInfo;

    public HospitalController(IHospitalInfo hospitalInfo)
    {
        _hospitalInfo = hospitalInfo;
    }

    public IActionResult Index(int pageNumber=1, int pageSize=10)
    {
        return View(_hospitalInfo.GetAll(pageNumber, pageSize));
    }

    [HttpGet]
    public IActionResult Edit(Guid id) 
    {
        HospitalInfoViewModel viewModel = _hospitalInfo.GetHospitalById(id);
        return View(viewModel);
    }


    [HttpPost]
    public IActionResult Edit(HospitalInfoViewModel hospitalInfoViewModel)
    {
        _hospitalInfo.UpdateHospitalInfo(hospitalInfoViewModel);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(HospitalInfoViewModel hospitalInfoViewModel)
    {
        _hospitalInfo.InsertHospital(hospitalInfoViewModel);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(Guid id)
    {
        _hospitalInfo.DeleteHospital(id);
        return RedirectToAction("Index");
    }
}
