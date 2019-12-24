using Microsoft.AspNetCore.Mvc;
using Madlibs.Models;

namespace Madlibs.Controllers
{
  public class HomeController : Controller
  {


    [Route("/")]
    public ActionResult MadlibsInputForm() { return View(); }

    [Route("/madlib")]
    public ActionResult MadlibsDisplay(string person1, string person2, string animal, string exclamation, string verb, string noun)
    {
      MadlibsVariable madLib = new MadlibsVariable();
      madLib.Person1 = person1;
      madLib.Person2 = person2;
      madLib.Animal = animal;
      madLib.Exclamation = exclamation;
      madLib.Verb = verb;
      madLib.Noun = noun;
      return View(madLib);
    }

  }
}
