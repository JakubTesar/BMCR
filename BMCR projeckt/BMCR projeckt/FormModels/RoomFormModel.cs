using System.ComponentModel.DataAnnotations;

namespace BMCR_projeckt.FormModels;

public class RoomFormModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string BuildingID { get; set; }

}