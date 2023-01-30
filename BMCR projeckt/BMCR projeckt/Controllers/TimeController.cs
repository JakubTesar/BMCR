using BMCR_projeckt.FormModels;
using BMCR_projeckt.Services;
using BMCR_projeckt.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMCR_projeckt.Controllers;

public class TimeController : Controller
{
    public TimeService Ts = new TimeService();
    public RoomService Rs = new RoomService();
    public IActionResult CreateTime(string RoomID)
    {
        TimeFormModel t = new TimeFormModel();
        t.RoomID = RoomID;
        return View(t);
    }

    [HttpPost]
    public IActionResult CreateTime(TimeFormModel Time)
    {
        TimeViewModel t = new TimeViewModel();
        t.Description = Time.Description;
        Guid guid = Guid.NewGuid();
        t.ID = guid.ToString();
        t.RoomID = Time.RoomID;
        t.From = Time.From;
        t.To = Time.To;
        if (CheckVolidTime(t))
        {
            Ts.AddTime(t, t.RoomID);
        }
        else
        {
            ViewData["Error"] = "Times collides";
            return View(Time);
        }
        return Redirect("../Create/Index");
    }
    public IActionResult DeleteTime(string ID, string RoomID)
    {
        Ts.SaveAll(Ts.DeleteTime(ID, RoomID), RoomID);
        return Redirect("/Create");
    }
    public IActionResult EditTime(string ID, string RoomID)
    {
        return View(Ts.Filter(ID, RoomID));
    }
    [HttpPost]
    public IActionResult EditTime(TimeViewModel Time)
    {
        if (CheckVolidTime(Time))
        {
            Ts.EditTime(Time, Time.RoomID);
        }
        else
        {
            ViewData["Error"] = "Times collides";
            return View(Time);
        }
        return View();
    }

    public bool CheckVolidTime(TimeViewModel t)
    {
        foreach (TimeViewModel t2 in Ts.GetTimes(t.RoomID))
        {
            if (t.From < t2.To && t2.From < t.To)
            {
                return false;
            }
        }
        return true;
    }
}