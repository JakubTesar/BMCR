using BMCR_projeckt.FormModels;
using BMCR_projeckt.Services;
using BMCR_projeckt.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMCR_projeckt.Controllers;

public class CreateRoomController : Controller
{
    public RoomService Rs = new RoomService();
    public BuildingService Bs = new BuildingService();
    public IActionResult CreateRoom()
    {
        return View(new RoomFormModel());
    }

    [HttpPost]
    public IActionResult CreateRoom(RoomFormModel Room)
    {
        RoomViewModel r = new RoomViewModel();
        r.Name = Room.Name;
        Guid guid = Guid.NewGuid();
        r.ID = guid.ToString();
        Rs.AddRoom(r, Room);
        return View();
    }
}