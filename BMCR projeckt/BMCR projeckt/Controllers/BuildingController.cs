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
        return View(Bs.Br.Buildings);
    }
    public IActionResult CreateBuilding()
    {
        return View(Bs.Br.Buildings);
    }
    [HttpPost]
    public IActionResult CreateBuilding(BuildingViewModel Building)
    {
        BuildingViewModel b = new BuildingViewModel();
        b.Name = Building.Name;
        b.Rooms = new List<RoomViewModel>();
        Bs.AddBuilding(b);
        return View(Bs.Br.Buildings);
    }
}