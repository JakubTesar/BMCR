using BMCR_projeckt.Repositories;
using BMCR_projeckt.ViewModels;

namespace BMCR_projeckt.Services;

public class BuildingService
{
    public BuildingsRepository Br = new BuildingsRepository();

    public void AddBuilding(BuildingViewModel Building)
    {
        BuildingViewModel b = new BuildingViewModel();
        b.Name = Building.Name;
        b.Rooms = new List<RoomViewModel>();
        Br.Buildings = new List<BuildingViewModel>();
            Br.Buildings.Add(b);
    }
}