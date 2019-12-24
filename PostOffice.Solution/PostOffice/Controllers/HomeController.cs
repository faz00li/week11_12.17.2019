using Microsoft.AspNetCore.Mvc;
using PostOffice.Models;
using System.Collections.Generic;

namespace PostOffice.Controllers
{
  public class HomeController : Controller
  {
    List<Parcel> inventory = Parcel.Inventory();

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
