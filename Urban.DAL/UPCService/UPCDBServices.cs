using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urban.DAL.Contexts;
using Urban.DAL.Models;

namespace Urban.DAL.UPCService
{
    public class UPCDBServices:IUPCDbServices
    {
        private readonly UPCDbContext _context;

        public UPCDBServices(UPCDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ServiceCategories>> GetAllServiceCategories()
        {
            return await _context.ServiceCategories.ToListAsync();
        }

        public async Task<ServiceCategories> GetServiceCategoriesById(int id)
        {
            return await _context.ServiceCategories.FindAsync(id);
        }
        public async Task<ServiceCategories> GetServiceCategoriesByName(string serviceName)
        {
            return await _context.ServiceCategories.Where(s=>s.category_name.ToUpper().Equals(serviceName.ToUpper())).FirstOrDefaultAsync();
        }

        public async void AddServiceCategories(ServiceCategories serviceCategories)
        {
           await  _context.ServiceCategories.AddAsync(serviceCategories);
            _context.SaveChanges();
        }

        public async void UpdateServiceCategories(ServiceCategories serviceCategories)
        {
             _context.ServiceCategories.Update(serviceCategories);
            await _context.SaveChangesAsync();
        }

        #region "Service Providers start"

        public async Task<IEnumerable<ServiceProviders>> GetAllServiceProviders()
        {
            return await _context.ServiceProviders.ToListAsync();
        }

        public  async Task<ServiceProviders> GetServiceProvidersById(int id)
        {
            return await _context.ServiceProviders.FindAsync(id);
        }

        public async void AddServiceProviders(ServiceProviders serviceProviders)
        {
          await  _context.ServiceProviders.AddAsync(serviceProviders);
            _context.SaveChanges();
        }

        public async void UpdateServiceProviders(ServiceProviders serviceProviders)
        {
            _context.ServiceProviders.Update(serviceProviders);
           await  _context.SaveChangesAsync();
        }

        #endregion "Service Providers end"



        #region "Services start"

        public async Task<IEnumerable<Services>> GetAllServices()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Services> GetServicesById(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async void AddServices(Services services)
        {
           await  _context.Services.AddAsync(services);
            _context.SaveChanges();
        }

        public async void UpdateServices(Services services)
        {
            _context.Services.Update(services);
           await  _context.SaveChangesAsync();
        }

        #endregion "Services end"

    }
}
