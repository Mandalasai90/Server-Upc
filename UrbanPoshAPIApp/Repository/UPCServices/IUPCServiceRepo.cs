using Urban.BAL.Requests;
using Urban.BAL.Responses;
using Urban.DAL.Models;

namespace UrbanPoshAPIApp.Repository.UPCServices
{
    public interface IUPCServiceRepo
    {
        Task<IEnumerable<ServiceCategories>> GetAllServiceCategories();
        Task<ResponseMessages> CreateServiceCategories(ServiceCategoriesRequest serviceCategories);
        Task<ResponseMessages> UpdateServiceCategories(UpdateServiceCategoriesRequest serviceCategories);
        Task<IEnumerable<ServiceProviders>> GetAllServiceProviders();
        Task<ResponseMessages> CreateServiceProviders(ServiceProvidersRequest serviceProvidersRequest);
        Task<ResponseMessages> UpdateServiceProviders(UpdateServiceProvidersRequest updateServiceProvidersRequest);
        Task<IEnumerable<Services>> GetAllServices();
        Task<ResponseMessages> CreateServices(ServicesRequest servicesRequest);
        Task<ResponseMessages> UpdateServices(UpdateServicesRequest updateServicesRequest);
    }
}
