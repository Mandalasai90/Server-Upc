using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urban.DAL.Models
{
    public class Services:UPCDefaultDate
    {
        [Key]
        public int service_id { get; set; }
        public int provider_id { get; set; }
        public ServiceProviders serviceProviders { get; set; }
        public string service_name { get; set; }
        public string service_description { get; set;}
        public decimal price { get; set; }
        public int duration { get; set; }
    }
}
