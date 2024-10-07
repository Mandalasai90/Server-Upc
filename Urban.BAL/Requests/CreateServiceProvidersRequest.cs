using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urban.BAL.Requests
{
    public class CreateServiceProvidersRequest
    {
        public string userId {  get; set; }
        public string Service_CategoryId { get; set; }
        public int rating { get; set; } 
        public int experienceinyears {  get; set; }
        public string bio { get; set; }
        public string availability { get; set; }
    }

    public class ServiceCategoriesRequest
    {
        public string category_Name { get; set; }
        public string description { get; set; }
    }

    public class ServicesRequest
    {
        public int providerId { get; set; }
        public string service_Name { get; }
        public string service_Description { get; set; }
        public decimal price { get; set; }
        public int duration { get; set; }
    }
    public class ServiceRatingsRequest
    {
        public int serviceId { get; set; }
        public int userId { get; set; }
        public int rating { get; set; }
        public string comments { get; set; }
    }
}
