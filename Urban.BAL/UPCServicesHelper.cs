using System.Net.Http.Headers;
using Urban.BAL.Responses;
using Urban.DAL.Models;
using Urban.DAL.UPCService;

namespace Urban.BAL
{
    public class UPCServicesHelper
    {
        private readonly IUPCDbServices _upcDbService;

        public UPCServicesHelper(IUPCDbServices uPCDbServices) { 
            _upcDbService = uPCDbServices;
        }

        public async Task<IEnumerable<ServiceCategories>> GetAllServiceCategories()
        {
            try
            {
               return await  _upcDbService.GetAllServiceCategories();
            }
            catch(Exception ex)
            {                

                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> CreateServiceCategories(ServiceCategories serviceCategories)
        {
            ResponseMessages responseMessages = new ResponseMessages(); 
            try
            {
                var servicecategory = await _upcDbService.GetServiceCategoriesByName(serviceCategories.category_name);
                if (serviceCategories != null)
                {
                    responseMessages.statusCode = UPCContants.FailedStatusCode;
                    responseMessages.message = UPCContants.ServiceCategory_Already_Create_Msg;
                }
                else
                {        
                    _upcDbService.AddServiceCategories(serviceCategories);
                    responseMessages.statusCode = UPCContants.SuccessStatusCode;
                    responseMessages.message = UPCContants.ServiceCategory_Create_Success_Msg;
                }

               return  responseMessages;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> UpdateServiceCategories(ServiceCategories serviceCategories)
        {
            ResponseMessages responseMessages = new ResponseMessages();
            try
            {
                 _upcDbService.UpdateServiceCategories(serviceCategories);
                responseMessages.statusCode = UPCContants.SuccessStatusCode;
                responseMessages.message = UPCContants.ServiceCategory_Update_Success_Msg;
                return  responseMessages;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ServiceProviders>> GetAllServiceProviders()
        {
            try
            {
                return await _upcDbService.GetAllServiceProviders();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> CreateServiceProviders(ServiceProviders serviceProviders)
        {
            ResponseMessages responseMessages = new ResponseMessages();
            try
            {
                _upcDbService.AddServiceProviders(serviceProviders);
                responseMessages.statusCode = UPCContants.SuccessStatusCode;
                responseMessages.message = UPCContants.ServiceProvider_Create_Success_Msg;

                return responseMessages;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> UpdateServiceProviders(ServiceProviders serviceProviders)
        {
            ResponseMessages responseMessages = new ResponseMessages();
            try
            {
                _upcDbService.UpdateServiceProviders(serviceProviders);
                responseMessages.statusCode = UPCContants.SuccessStatusCode;
                responseMessages.message = UPCContants.ServiceProvider_Update_Success_Msg;
                return responseMessages;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<Services>> GetAllServices()
        {
            try
            {
                return await _upcDbService.GetAllServices();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> CreateServices(Services services)
        {
            ResponseMessages responseMessages = new ResponseMessages();
            try
            {
                _upcDbService.AddServices(services);
                responseMessages.statusCode = UPCContants.SuccessStatusCode;
                responseMessages.message = UPCContants.Services_Create_Success_Msg;

                return responseMessages;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> UpdateServices(Services services)
        {
            ResponseMessages responseMessages = new ResponseMessages();
            try
            {
                _upcDbService.UpdateServices(services);
                responseMessages.statusCode = UPCContants.SuccessStatusCode;
                responseMessages.message = UPCContants.Services_Update_Success_Msg;
                return responseMessages;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}