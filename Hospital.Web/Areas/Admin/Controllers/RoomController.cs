using Hospital.Models;
using Hospital.Repositories.Interface;
using Hospital.Services.Interfaces;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Web.Areas.Admin.Controllers;
[Area("admin")]
public class RoomController : Controller
{
    private IRoomService _roomService;
    private IUnitOfWork _unitOfWork;

    public RoomController(IRoomService roomService, IUnitOfWork unitOfWork)
    {
        _roomService = roomService;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index(int pageNumber=1, int pageSize=10)
    {
        return View(_roomService.GetAll(pageNumber, pageSize));
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        ViewBag.hospital = new SelectList(_unitOfWork.Repository<HospitalInfo>().GetAll(), "Id", "Name");
        RoomViewModel result = _roomService.GetRoomById(id);
        return View(result);
    }

    [HttpPost]
    public IActionResult Edit(RoomViewModel roomViewModel)
    {
        _roomService.UpdateRoom(roomViewModel);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.hospital = new SelectList(_unitOfWork.Repository<HospitalInfo>().GetAll(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(RoomViewModel roomViewModel)
    {
        _roomService.InsertRoom(roomViewModel);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(Guid id)
    {
        _roomService.DeleteRoom(id);
        return RedirectToAction("Index");
    }
}
