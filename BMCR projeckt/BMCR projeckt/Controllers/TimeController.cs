﻿using BMCR_projeckt.FormModels;
using BMCR_projeckt.Services;
using BMCR_projeckt.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMCR_projeckt.Controllers;

public class TimeController : Controller
{
    public TimeService Ts = new TimeService();
    public RoomService Rs = new RoomService();
    public IActionResult CreateTime()
    {
        return View(new TimeFormModel());
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
        Ts.AddTime(t, t.RoomID);
        //Bs.Filter(r.BuildingID).Rooms = Rs.GetRooms(r.BuildingID);
       // Rs.Filter(t.RoomID, )
        return View();
    }

    public IActionResult EditTime()
    {
        return View();
    }
    
    public void DeleteTime()
    {
        
    }
}