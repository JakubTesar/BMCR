using BMCR_projeckt.ViewModels;

namespace BMCR_projeckt.Repositories;

public class RoomRepository
{
    public List<RoomViewModel> Rooms { get; set; }

    public RoomRepository()
    {
        Rooms = new List<RoomViewModel>();
    }

    public void AddRoom(RoomViewModel r, string BuildingID)
    {
        Rooms.Add(r);
        string a = r.Name + ";" + r.ID;
        TextWriter tsw = new StreamWriter("Rooms/roomsOf" + BuildingID + ".txt", true);
        tsw.WriteLine(a);
        tsw.Close();
    }

    public List<RoomViewModel> LoadAll(string BuildingID)
    {
        List<RoomViewModel> rVMs = new List<RoomViewModel>();
        if (File.Exists("Rooms/roomsOf" + BuildingID + ".txt"))
        {
            string[] lines = System.IO.File.ReadAllLines("Rooms/roomsOf" + BuildingID + ".txt");
            foreach (string line in lines)
            {
                string[] a = line.Split(";");
                RoomViewModel r = new RoomViewModel();
                r.Name = a[0];
                r.ID = a[1];
                rVMs.Add(r);
            }  
        }
        
        return rVMs;
    }

    public void SaveAll(List<RoomViewModel> rVMs, string BuildingID)
    {
        TextWriter tsw = new StreamWriter("Rooms/roomsOf" + BuildingID + ".txt", false);
        foreach (RoomViewModel r in rVMs)
        {
            string a = r.Name + ";" + r.ID;
            tsw.WriteLine(a);
        } 
        tsw.Close();
    }
}