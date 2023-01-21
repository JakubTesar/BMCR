using BMCR_projeckt.ViewModels;

namespace BMCR_projeckt.Repositories;

public class BuildingsRepository
{
    public List<BuildingViewModel> Buildings { get; set; }

    public BuildingsRepository()
    {
        Buildings = new List<BuildingViewModel>();
    }

    public void AddBuilding(BuildingViewModel b)
    {
        Buildings.Add(b);
        string a = b.Name + ";" + b.ID;
        TextWriter tsw = new StreamWriter("save.txt", true);
        tsw.WriteLine(a);
        tsw.Close();
    }

    public List<BuildingViewModel> LoadAll()
    {
        List<BuildingViewModel> bVMs = new List<BuildingViewModel>();
        string[] lines = System.IO.File.ReadAllLines("save.txt");
        foreach (string line in lines)
        {
            string[] a = line.Split(";");
            BuildingViewModel b = new BuildingViewModel();
            b.Name = a[0];
            b.ID = a[1];
            bVMs.Add(b);
        }

        return bVMs;
    }

    public void SaveAll(List<BuildingViewModel> bVMs)
    {
        TextWriter tsw = new StreamWriter("save.txt", false);
        foreach (BuildingViewModel b in bVMs)
        {
            string a = b.Name + ";" + b.ID;

            tsw.WriteLine(a);
        }

        tsw.Close();
    }
}