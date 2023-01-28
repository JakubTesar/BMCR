using BMCR_projeckt.FormModels;
using BMCR_projeckt.Services;
using BMCR_projeckt.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMCR_projeckt.Controllers;

public class CreateRoomController : Controller
{
    public RoomService Rs = new RoomService();
    public BuildingService Bs = new BuildingService();
    public IActionResult CreateRoom(string BuildingID)
    {
        RoomFormModel rFM = new RoomFormModel();
        rFM.BuildingID = BuildingID;
        return View(rFM);
    }
    [HttpPost]
    public IActionResult CreateRoom(RoomFormModel Room)
    {
        RoomViewModel r = new RoomViewModel();
        r.Name = Room.Name;
        Guid guid = Guid.NewGuid();
        r.ID = guid.ToString();
        r.BuildingID = Room.BuildingID;
        Rs.AddRoom(r, r.BuildingID);
        Bs.Filter(r.BuildingID).Rooms = Rs.GetRooms(r.BuildingID);
        return Redirect("../Create/Detail/"+Room.BuildingID);
    }
    public IActionResult DeleteRoom(string ID, string BuildingID)
    {
        Rs.SaveAll(Rs.DeleteRoom(ID, BuildingID), BuildingID);
        return Redirect("/Create");
    }
    public IActionResult EditRoom(string ID, string BuildingID)
    {
        return View(Rs.Filter(ID, BuildingID));
    }
    [HttpPost]
    public IActionResult EditRoom(RoomViewModel Room)
    {
        Rs.EditRoom(Room, Room.BuildingID);
        return View();
    }
    public IActionResult DetailRoom(string ID, string BuildingID)
    {
        TimeService Ts = new TimeService();
        RoomViewModel rVM = new RoomViewModel();
        rVM = Rs.Filter(ID,BuildingID);
        rVM.Times = Ts.GetTimes(ID);
        rVM.BuildingID = BuildingID;
        return View(rVM);
    }
}