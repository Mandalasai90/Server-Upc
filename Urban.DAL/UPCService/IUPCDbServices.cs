using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urban.DAL.Models;

namespace Urban.DAL.UPCService
{
    public interface IUPCDbServices
    {
       Task<IEnumerable<ServiceCategories>> GetAllServiceCategories();
       Task<ServiceCategories> GetServiceCategoriesById(int id);
        Task<ServiceCategories> GetServiceCategoriesByName(string serviceName);
       void AddServiceCategories(ServiceCategories serviceCategories);
       void UpdateServiceCategories(ServiceCategories serviceCategories);

        Task<IEnumerable<ServiceProviders>> GetAllServiceProviders();
        Task<ServiceProviders> GetServiceProvidersById(int id);
        void AddServiceProviders(ServiceProviders serviceProviders);
        void UpdateServiceProviders(ServiceProviders serviceProviders);

        Task<IEnumerable<Services>> GetAllServices();
        Task<Services> GetServicesById(int id);
        void AddServices(Services services);
        void UpdateServices(Services services);
    }

}
