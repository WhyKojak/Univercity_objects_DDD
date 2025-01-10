using Microsoft.AspNetCore.Mvc;

namespace Univercity_objects.API.Controllers;

[Controller]
[Route("/")]
public class MainController : Controller
{
    [HttpGet]
    public ActionResult GetMainPage()
    { 
        return View("Main");
    }
}
