namespace BMCR_projeckt.ViewModels;

public class BuildingViewModel
{
    public string Name { get; set; }
    public List<RoomViewModel> Rooms = new List<RoomViewModel>();
    public string ID { get; set; }

}