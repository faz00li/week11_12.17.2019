using Microsoft.AspNetCore.Mvc;

namespace ErezSussman.Controllers
{
  public class AboutController : Controller
  {

    [HttpGet("/about")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
