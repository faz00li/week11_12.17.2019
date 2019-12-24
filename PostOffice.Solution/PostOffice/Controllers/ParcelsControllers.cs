using Microsoft.AspNetCore.Mvc;
using PostOffice.Models;
using System.Collections.Generic;

namespace PostOffice.Controllers
{
  public class ParcelsController : Controller
  {
    List<Parcel> inventory = Parcel.Inventory();

    [HttpGet("/parcels")]
    public ActionResult Index()
    {
      List<Parcel> parcelList = Parcel.Inventory();
      return View(parcelList);
    }

    [HttpGet("/parcels/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/parcels")]
    public ActionResult Create(string description, int height, int width, int weight)
    {
      Parcel newParcel = new Parcel(description, height, width, weight);

      return RedirectToAction("Index");
    }

    [HttpPost("/parcels/delete")]
    public ActionResult DeleteAll()
    {
      Parcel.ClearAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/parcels/{id}")]
    public ActionResult Show(int id)
    {
      Parcel showParcel = Parcel.Find(id);
      return View(showParcel);
    }


  }
}
