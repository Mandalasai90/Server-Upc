using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urban.BAL.Requests;
using UrbanPoshAPIApp.Repository.UPCServices;

namespace UrbanPoshAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IUPCServiceRepo _uPCServiceRepo;
        private readonly ILogger<ServicesController> _logger;
        public ServicesController(IUPCServiceRepo uPCServiceRepo, ILogger<ServicesController> logger) { 
        
            _uPCServiceRepo = uPCServiceRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllServiceCategory")]
        public async Task<IActionResult> GetAllServiceCategory()
        {
            try
            {
                return Ok(await _uPCServiceRepo.GetAllServiceCategories());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error from ServicesController-Method:GetAllServiceCategory",ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateServiceCategory")]
        public async Task<IActionResult> CreateServiceCategory([FromBody] ServiceCategoriesRequest serviceCategoriesRequest)
        {
            try
            {
                return Ok(await _uPCServiceRepo.CreateServiceCategories(serviceCategoriesRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error from ServicesController-Method:CreateServiceCategory", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateServiceCategory")]
        public async Task<IActionResult> UpdateServiceCategory([FromBody] UpdateServiceCategoriesRequest serviceCategoriesRequest)
        {
            try
            {
                return Ok(await _uPCServiceRepo.UpdateServiceCategories(serviceCategoriesRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error from ServicesController-Method:UpdateServiceCategory", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllServiceProviders")]
        public async Task<IActionResult> GetAllServiceProviders()
        {
            try
            {
                return Ok(await _uPCServiceRepo.GetAllServiceProviders());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error from ServicesController-Method:GetAllServiceProviders", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateServiceProviders")]
        public async Task<IActionResult> CreateServiceProviders([FromBody] ServiceProvidersRequest serviceProvidersRequest)
        {
            try
            {
                return Ok(await _uPCServiceRepo.CreateServiceProviders(serviceProvidersRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error from ServicesController-Method:CreateServiceProviders", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateServiceProviders")]
        public async Task<IActionResult> UpdateServiceProviders([FromBody] UpdateServiceProvidersRequest updateServiceProvidersReq)
        {
            try
            {
                return Ok(await _uPCServiceRepo.UpdateServiceProviders(updateServiceProvidersReq));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error from ServicesController-Method:UpdateServiceProviders", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            try
            {
                return Ok(await _uPCServiceRepo.GetAllServices());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error from ServicesController-Method:GetAllServices", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateServices")]
        public async Task<IActionResult> CreateServices([FromBody] ServicesRequest servicesRequest)
        {
            try
            {
                return Ok(await _uPCServiceRepo.CreateServices(servicesRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error from ServicesController-Method:CreateServices", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateServices")]
        public async Task<IActionResult> UpdateServices([FromBody] UpdateServicesRequest updateServicesRequest)
        {
            try
            {
                return Ok(await _uPCServiceRepo.UpdateServices(updateServicesRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error from ServicesController-Method:UpdateServices", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
