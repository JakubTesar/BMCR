namespace BMCR_projeckt.ViewModels;

public class RoomViewModel
{
    public string Name { get; set; }
    public string ID { get; set; }
    public string BuildingID { get; set; }
    public List<TimeViewModel> Times { get; set; }
}