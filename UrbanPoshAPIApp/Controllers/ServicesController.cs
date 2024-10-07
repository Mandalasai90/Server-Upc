using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UrbanPoshAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        public ServicesController() { 
        
        }
        [HttpPost]
        public IActionResult CreateServiceProvider()
        {

        }
    }
}
