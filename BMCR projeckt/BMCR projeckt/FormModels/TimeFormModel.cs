using System.ComponentModel.DataAnnotations;

namespace BMCR_projeckt.FormModels;

public class TimeFormModel
{
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime From { get; set; }
    [Required]
    public DateTime To { get; set; }
    public string ID { get; set; }
    [Required]
    public string RoomID { get; set; }
}