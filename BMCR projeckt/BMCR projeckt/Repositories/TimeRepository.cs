using BMCR_projeckt.ViewModels;

namespace BMCR_projeckt.Repositories;

public class TimeRepository
{
    public List<TimeViewModel> Times { get; set; }

    public TimeRepository()
    {
        Times = new List<TimeViewModel>();
    }

    public void AddTime(TimeViewModel t, string RoomID)
    {
        Times.Add(t);
        string a = t.Description + ";" + t.ID + ";" + t.From.ToString() + ";" + t.To;
        TextWriter tsw = new StreamWriter("Times/timesOf" + RoomID + ".txt", true);
        tsw.WriteLine(a);
        tsw.Close();
    }
    public List<TimeViewModel> LoadAll(string RoomID)
    {
        List<TimeViewModel> rVMs = new List<TimeViewModel>();
        if (File.Exists("Times/timesOf" + RoomID + ".txt"))
        {
            string[] lines = System.IO.File.ReadAllLines("Times/timesOf" + RoomID + ".txt");
            foreach (string line in lines)
            {
                string[] a = line.Split(";");
                TimeViewModel t = new TimeViewModel();
                t.Description = a[0];
                t.ID = a[1];
                t.From = DateTime.Parse(a[2]);
                t.To = DateTime.Parse(a[3]);
                rVMs.Add(t);
            }  
        }
        
        return rVMs;
    }
}