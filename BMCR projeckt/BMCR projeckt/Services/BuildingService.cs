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

    public List<BuildingViewModel> DeleteBuilding(string ID)
    {
        for (int i = 0; i < GetBuildings().Count; i++)
        {
            if (GetBuildings().ElementAt(i).ID == ID)
            {
                List<BuildingViewModel> a = GetBuildings();
                a.RemoveAt(i);
                return a;
            }
        }

        return new List<BuildingViewModel>();
    }

    public void SaveAll(List<BuildingViewModel> bVMs)
    {
        Br.SaveAll(bVMs);
    }

    public void EditBuilding(BuildingViewModel b)
    {for (int i = 0; i < GetBuildings().Count; i++)
        {
            if (GetBuildings().ElementAt(i).ID == b.ID)
            {
                List<BuildingViewModel> a = GetBuildings();
                a.ElementAt(i).Name = b.Name;
                SaveAll(a);
            }
        }
    }
    public BuildingViewModel Filter(string ID)
    {
        foreach (BuildingViewModel b in GetBuildings())
        {
            if (b.ID == ID)
            {
                return b;
            }
        }

        return new BuildingViewModel();
    }

}