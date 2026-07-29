using Microsoft.AspNetCore.Mvc;

namespace GestorTorneosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigController : ControllerBase
    {
        [HttpGet("layout")]
        public IActionResult GetLayoutConfig()
        {
            return Ok(new
            {
                theme = "dark",
                version = "1.0.0",
                responsiveOptions = new { maxColumns = 4, showSidebar = true }
            });
        }
    }
}