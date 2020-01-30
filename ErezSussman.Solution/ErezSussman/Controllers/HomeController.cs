using Microsoft.AspNetCore.Mvc;

namespace ErezSussman.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
