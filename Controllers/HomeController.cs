using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public HomeView Index()
    {
        return new HomeView();
    }
}
