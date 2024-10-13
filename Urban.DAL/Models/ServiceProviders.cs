using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urban.DAL.Models
{
    public class ServiceProviders:UPCDefaultDate
    {
        [Key]
        public int provider_id { get; set; }

        public int user_id { get; set; }

        public User users { get; set; }

        public int service_category_id { get;set;}

        public ServiceCategories serviceCategories { get; set; }

        public decimal rating { get; set; }

        public int experience_years { get; set; }
        public string bio { get; set; }
        public string availability { get; set; }

        public ICollection<Services> services { get; set; }
    }
}
