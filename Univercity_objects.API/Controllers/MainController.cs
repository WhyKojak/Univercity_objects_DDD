using Microsoft.AspNetCore.Mvc;

namespace Univercity_objects.API.Controllers;

[Controller]
[Route("/")]
public class MainController : ControllerBase
{
    [HttpGet]
    public ActionResult GetMainPage()
    {
        return Ok();
    }
}
