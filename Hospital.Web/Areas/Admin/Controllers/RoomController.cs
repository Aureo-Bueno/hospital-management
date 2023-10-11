using Hospital.Services.Interfaces;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers;
[Area("admin")]
public class RoomController : Controller
{
    private IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public IActionResult Index(int pageNumber=1, int pageSize=10)
    {
        return View(_roomService.GetAll(pageNumber, pageSize));
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
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
