using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using fms.Models;
using Microsoft.AspNetCore.Http;

namespace fms.Controllers{
public class BookingController : Controller {
    
    public  ACE42023Context db = new();


    public ActionResult GetBooking(){
        ViewBag.Username = HttpContext.Session.GetString("Username");
        ViewBag.user_name = HttpContext.Session.GetString("user_name");
        int userId = Convert.ToInt32(ViewBag.Username);
        List<IBooking> result = new List<IBooking>();
        result = db.IBookings.Where( x => x.UserId == userId).Select(x => x).ToList();
        if(ViewBag.Username != null){
            return View(result);
        }
        return RedirectToAction("login","Login");
    }

    public ActionResult Create(){
        return View();
    }

    // public ActionResult Create(int id){
    //     return RedirectToAction("GetBooking");
    // }
    [HttpPost]
    public ActionResult Create(IFlight p){
        DateTime dt = Convert.ToDateTime(Request.Form["FlightDate"]);
        System.Console.WriteLine(dt);
        List<IFlight> pq = db.IFlights.Where( x => (x.Origin == p.Origin & x.Destination == p.Destination & (x.FlightDate >= dt))).ToList();
        return View(pq);
    }


    [HttpGet]
    public ActionResult Edit(int id){
        IBooking p = db.IBookings.Where(x=>x.BookingId == id).SingleOrDefault();
        return View(p);
    }

    [HttpPost]
    public ActionResult Edit(IBooking p){
        db.IBookings.Update(p);
        db.SaveChanges();
        return RedirectToAction("GetBooking");
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        IBooking p = db.IBookings.Find(id);
        return View(p);
    }

    [HttpPost]
    [ActionName("Delete")] // c# compiler as alternate of overloading
    public ActionResult DeleteConfirmed(int id){
        IBooking p = db.IBookings.Find(id);
        db.IBookings.Remove(p);
        db.SaveChanges();
        return RedirectToAction("GetBooking");
    }

    public ActionResult UserDetail(int id){
        IUser p  = db.IUsers.Find(id);
        return View(p); 
    }

    public ActionResult FlightDetail(int id){
        IFlight p  = db.IFlights.Find(id);
        return View(p); 
    }

    // public ActionResult TicketBooked(){
    //     return View();
    // }


     [HttpGet]
    public ActionResult TicketBooked(int id){
        try{
        IBooking p = new IBooking();
        System.Random r = new System.Random();
        p.BookingId = r.Next();
        p.FlightId = id;
        p.UserId =  Convert.ToInt32(ViewBag.Username);;
        p.SeatNumber = "1A";
        p.BookingDate = DateTime.Now;
        System.Console.WriteLine(id);
        db.IBookings.Add(p);
        db.SaveChanges();
        }
        catch{
            RedirectToAction("TicketBooked");
        }
        return View();
    }
    [HttpPost]
    public ActionResult TicketBooked(IBooking p){
        try{
        db.IBookings.Add(p);
        db.SaveChanges();
        }
        catch(Exception e){
            System.Console.WriteLine(e.Message + " " + p.BookingId);
            return RedirectToAction("GetBooking");
        }
        return RedirectToAction("GetBooking");
    }



}
}
