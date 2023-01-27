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
}