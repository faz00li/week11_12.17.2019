using Microsoft.AspNetCore.Mvc;

namespace ErezSussman.Controllers
{
  public class AudioController : Controller
  {

    [HttpGet("/Audio")]
    public ActionResult Audio()
    {
      return View();
    }

  }
}
