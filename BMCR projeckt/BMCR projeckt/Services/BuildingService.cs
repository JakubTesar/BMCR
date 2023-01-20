using BMCR_projeckt.Repositories;
using BMCR_projeckt.ViewModels;

namespace BMCR_projeckt.Services;

public class BuildingService
{
    public BuildingsRepository Br = new BuildingsRepository();

    public void AddBuilding(BuildingViewModel Building)
    {
        Br.AddBuilding(Building);
    }

    public List<BuildingViewModel> GetBuildings()
    {
        return Br.LoadAll();
    }
}