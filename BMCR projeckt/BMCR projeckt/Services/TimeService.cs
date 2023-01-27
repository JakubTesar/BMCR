using BMCR_projeckt.Repositories;
using BMCR_projeckt.ViewModels;

namespace BMCR_projeckt.Services;

public class TimeService
{
    public TimeRepository Tr = new TimeRepository();
    
    public void AddTime(TimeViewModel Time, string RoomID)
    {
        Tr.AddTime(Time,RoomID);
    }
    public List<TimeViewModel> GetTimes(string RoomID)
    {
        return Tr.LoadAll(RoomID);
    }
    public List<TimeViewModel> DeleteTime(string ID, string RoomID)
    {
        for (int i = 0; i < GetTimes(RoomID).Count; i++)
        {
            if (GetTimes(RoomID).ElementAt(i).ID == ID)
            {
                List<TimeViewModel> a = GetTimes(RoomID);
                a.RemoveAt(i);
                return a;
            }
        }
        return new List<TimeViewModel>();
    }
    public void SaveAll(List<TimeViewModel> tVMs, string RoomID)
    {
        Tr.SaveAll(tVMs, RoomID);
    }
    public void EditTime(TimeViewModel t, string RoomID)
    {
        for (int i = 0; i < GetTimes(RoomID).Count; i++)
        {
            if (GetTimes(RoomID).ElementAt(i).ID == t.ID)
            {
                List<TimeViewModel> a = GetTimes(RoomID);
                a.ElementAt(i).Description = t.Description;
                a.ElementAt(i).ID = t.ID;
                a.ElementAt(i).To = t.To;
                a.ElementAt(i).From = t.From;
                SaveAll(a, RoomID);
            }
        }
    }
    public TimeViewModel Filter(string ID, string RoomID)
    {
        foreach (TimeViewModel t in GetTimes(RoomID))
        {
            if (t.ID == ID)
            {
                return t;
            }
        }

        return new TimeViewModel();
    }
}