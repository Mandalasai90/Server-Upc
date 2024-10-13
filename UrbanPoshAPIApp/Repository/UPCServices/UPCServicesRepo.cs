using Urban.BAL;
using Urban.BAL.Requests;
using Urban.BAL.Responses;
using Urban.DAL.Models;
using Urban.DAL.UPCService;

namespace UrbanPoshAPIApp.Repository.UPCServices
{
    public class UPCServicesRepo:IUPCServiceRepo
    {
        private readonly UPCServicesHelper uPCServicesHelper;
        private readonly IUPCDbServices _uPCDbServices;
        public UPCServicesRepo(IUPCDbServices uPCDbServices) {
            _uPCDbServices = uPCDbServices;
            uPCServicesHelper=new UPCServicesHelper(_uPCDbServices);
        }

        public async Task<IEnumerable<ServiceCategories>> GetAllServiceCategories()
        {
            try
            {
                 return await uPCServicesHelper.GetAllServiceCategories();
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> CreateServiceCategories(ServiceCategoriesRequest serviceCategoriesRequest)
        {
            
            try
            {
                ServiceCategories serviceCategories1= new ServiceCategories();
                serviceCategories1.category_name = serviceCategoriesRequest.categoryName;
                serviceCategories1.description= serviceCategoriesRequest.description;
                serviceCategories1.CreatedAt = DateTime.Now;
                serviceCategories1.UpdatedAt = DateTime.Now;

             return await uPCServicesHelper.CreateServiceCategories(serviceCategories1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> UpdateServiceCategories(UpdateServiceCategoriesRequest updateServiceCategoriesRequest)
        {
            
            try
            {
                ServiceCategories serviceCategories1 = new ServiceCategories();
                serviceCategories1.service_category_id = updateServiceCategoriesRequest.CategoryId;
                serviceCategories1.category_name = updateServiceCategoriesRequest.categoryName;
                serviceCategories1.description = updateServiceCategoriesRequest.description;
                serviceCategories1.CreatedAt = DateTime.Now;
                serviceCategories1.UpdatedAt = DateTime.Now;
                return await uPCServicesHelper.UpdateServiceCategories(serviceCategories1);
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
                return await uPCServicesHelper.GetAllServiceProviders();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> CreateServiceProviders(ServiceProvidersRequest serviceProvidersRequest)
        {

            try
            {
                ServiceProviders serviceProviders = new ServiceProviders();
                serviceProviders.user_id = serviceProvidersRequest.userId;
                serviceProviders.service_category_id = serviceProvidersRequest.Service_CategoryId;
                serviceProviders.rating= serviceProvidersRequest.rating;
                serviceProviders.experience_years = serviceProvidersRequest.experienceinyears;
                serviceProviders.availability = serviceProvidersRequest.availability;
                serviceProviders.bio = serviceProvidersRequest.bio;
                serviceProviders.CreatedAt = DateTime.Now;
                serviceProviders.UpdatedAt = DateTime.Now;

                return await uPCServicesHelper.CreateServiceProviders(serviceProviders);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> UpdateServiceProviders(UpdateServiceProvidersRequest updateServiceProvidersRequest)
        {

            try
            {
                ServiceProviders serviceProviders = new ServiceProviders();
                serviceProviders.user_id = updateServiceProvidersRequest.userId;
                serviceProviders.service_category_id = updateServiceProvidersRequest.Service_CategoryId;
                serviceProviders.rating = updateServiceProvidersRequest.rating;
                serviceProviders.experience_years = updateServiceProvidersRequest.experienceinyears;
                serviceProviders.availability = updateServiceProvidersRequest.availability;
                serviceProviders.bio = updateServiceProvidersRequest.bio;
                serviceProviders.CreatedAt = DateTime.Now;
                serviceProviders.UpdatedAt = DateTime.Now;
                return await uPCServicesHelper.UpdateServiceProviders(serviceProviders);
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
                return await uPCServicesHelper.GetAllServices();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> CreateServices(ServicesRequest servicesRequest)
        {

            try
            {
                Services objservices = new Services();
                objservices.provider_id = servicesRequest.providerId;
                objservices.price = servicesRequest.price;
                objservices.service_description = servicesRequest.service_Description;
                objservices.duration = servicesRequest.duration;
                objservices.service_description = servicesRequest.service_Description;
                objservices.service_name = servicesRequest.service_Name;

                objservices.CreatedAt = DateTime.Now;
                objservices.UpdatedAt = DateTime.Now;

                return await uPCServicesHelper.CreateServices(objservices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseMessages> UpdateServices(UpdateServicesRequest updateServicesRequest)
        {

            try
            {
                Services objservices = new Services();
                objservices.provider_id = updateServicesRequest.providerId;
                objservices.price = updateServicesRequest.price;
                objservices.service_description = updateServicesRequest.service_Description;
                objservices.duration = updateServicesRequest.duration;
                objservices.service_description = updateServicesRequest.service_Description;
                objservices.service_name = updateServicesRequest.service_Name;
                objservices.CreatedAt = DateTime.Now;
                objservices.UpdatedAt = DateTime.Now;

                return await uPCServicesHelper.UpdateServices(objservices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
