using BMCR_projeckt.Services;
using BMCR_projeckt.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMCR_projeckt.Controllers;

public class Create : Controller
{
    public BuildingService Bs = new BuildingService();
    // GET
    /*public IActionResult Index()
    {
        return View();
    }*/
    
    [HttpPost]
    public IActionResult CreateBuilding(BuildingViewModel Building)
    {
        Bs.AddBuilding(Building);
        return View();
    }
}