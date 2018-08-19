using Microsoft.AspNetCore.Mvc;
namespace QuoteService
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<string> Get()
        {
            return "New quotes are available!";
        }
    }
}
