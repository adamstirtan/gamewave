using Microsoft.AspNetCore.Mvc;

namespace FinalBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
