using BMCR_projeckt.Repositories;
using BMCR_projeckt.ViewModels;

namespace BMCR_projeckt.Services;

public class RoomService
{
    public RoomRepository Rm = new RoomRepository();

    public void AddRoom(RoomViewModel Room, string BuildingID)
    {
        Rm.AddRoom(Room, BuildingID);
    }

    public List<RoomViewModel> GetRooms(string BuildingID)
    {
        return Rm.LoadAll(BuildingID);
    }

    public List<RoomViewModel> DeleteRoom(string ID, string BuildingID)
    {
        for (int i = 0; i < GetRooms(BuildingID).Count; i++)
        {
            if (GetRooms(BuildingID).ElementAt(i).ID == ID)
            {
                List<RoomViewModel> a = GetRooms(BuildingID);
                a.RemoveAt(i);
                return a;
            }
        }

        return new List<RoomViewModel>();
    }

    public void SaveAll(List<RoomViewModel> rVMs, string BuildingID)
    {
        Rm.SaveAll(rVMs, BuildingID);
    }

    public void EditRoom(RoomViewModel r, string BuildingID)
    {
        for (int i = 0; i < GetRooms(BuildingID).Count; i++)
        {
            if (GetRooms(BuildingID).ElementAt(i).ID == r.ID)
            {
                List<RoomViewModel> a = GetRooms(BuildingID);
                BuildingService Bs = new BuildingService();
                RoomService Rs = new RoomService();
                a.ElementAt(i).Name = r.Name;
                //Bs.Filter(BuildingID).Rooms.ElementAt(i).Name = Rs.GetRooms(r.BuildingID).ElementAt(i).Name;
                SaveAll(a, BuildingID);
            }
        }
    }
   
    public RoomViewModel Filter(string ID, string BuildingID)
    {
        foreach (RoomViewModel r in GetRooms(BuildingID))
        {
            if (r.ID == ID)
            {
                return r;
            }
        }

        return new RoomViewModel();
    }
}