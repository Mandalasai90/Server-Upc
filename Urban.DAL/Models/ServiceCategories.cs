using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urban.DAL.Models
{
    public class ServiceCategories: UPCDefaultDate
    {
        [Key]
        public int service_category_id { get; set; }
        public string category_name { get; set; }
        public string description { get; set; }
        public ICollection<ServiceProviders> serviceProviders { get; set; }
    }
}
