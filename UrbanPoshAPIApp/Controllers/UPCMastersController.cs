using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urban.BAL.Requests;

namespace UrbanPoshAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UPCMastersController : ControllerBase
    {
        private readonly ILogger<UPCMastersController> _logger;

        public UPCMastersController(ILogger<UPCMastersController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public  IActionResult Login(LoginRequest loginRequest)
        {
            try
            {
                
                return  Ok("123");
            }
            catch(Exception ex)
            {
                _logger.LogError("UPCMastersController-Method:Login:" + ex.Message);
                throw ex;
            }
        }
    }
}
