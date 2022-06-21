using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RESTController : ControllerBase
    {
        [HttpGet]
        public IActionResult  Get()
        {
            return Ok( "Det tar en time å gå til ørsta rådhus"); //Returns a http-response code of 200 with the appropriate content
        }

        [HttpPost]
        public IActionResult Post(int hoursToWalkToØrstaRådhus)
        {
            if (hoursToWalkToØrstaRådhus != 1) {
                return BadRequest("Det skal ta en time å gå til ørsta rådhus");
            }
            return Ok("Ikkje at eg he noko der å gjer");
        }
    }
}
