using BMCR_projeckt.FormModels;
using BMCR_projeckt.Services;
using BMCR_projeckt.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMCR_projeckt.Controllers;

public class Create : Controller
{
    public BuildingService Bs = new BuildingService();

    // GET
    public IActionResult Index()
    {
        return View(Bs.GetBuildings());
    }

    public IActionResult CreateBuilding()
    {
        return View(new BuildingFormModels());
    }

    [HttpPost]
    public IActionResult CreateBuilding(BuildingFormModels Building)
    {
        BuildingViewModel b = new BuildingViewModel();
        b.Name = Building.Name;
        b.Rooms = new List<RoomViewModel>();
        Guid guid = Guid.NewGuid();
        b.ID = guid.ToString();
        Bs.AddBuilding(b);
        return Redirect("Index");
    }

    public IActionResult DeleteBuilding(string ID)
    {
        Bs.SaveAll(Bs.DeleteBuilding(ID));
        return Redirect("/Create");
    }

    public IActionResult EditBuilding(string ID)
    {
        return View(Bs.Filter(ID));
    }

    [HttpPost]
    public IActionResult EditBuilding(BuildingViewModel Building)
    {
        Bs.EditBuilding(Building);
        return Redirect("/Create");
    }

    public IActionResult Detail(string ID)
    {
        RoomService Rs = new RoomService();
        BuildingViewModel bVM = new BuildingViewModel();
        bVM = Bs.Filter(ID);
        bVM.Rooms = Rs.GetRooms(ID);
        return View(bVM);
    }
}