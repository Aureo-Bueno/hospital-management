using Hospital.Models;
using Hospital.Repositories.Interface;
using Hospital.Services.Interfaces;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Web.Areas.Admin.Controllers;
[Area("admin")]
public class ContactController : Controller
{
    private IContactService _contactService;
    IUnitOfWork _unitOfWork;
    public ContactController(IContactService contactService, IUnitOfWork unitOfWork)
    {
        _contactService = contactService;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index(int pageNumber = 1, int pageSize = 10)
    {
        return View(_contactService.GetAll(pageNumber, pageSize));
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        ViewBag.hospital = new SelectList(_unitOfWork.Repository<HospitalInfo>().GetAll(), "Id", "Name");
        ContactViewModel result = _contactService.GetContactById(id);
        return View(result);
    }

    [HttpPost]
    public IActionResult Edit(ContactViewModel contactViewModel)
    {
        _contactService.UpdateContactInfo(contactViewModel);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.hospital = new SelectList(_unitOfWork.Repository<HospitalInfo>().GetAll(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(ContactViewModel contactViewModel)
    {
        _contactService.InsertContact(contactViewModel);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(Guid id)
    {
        _contactService.DeleteContact(id);
        return RedirectToAction("Index");
    }
}
