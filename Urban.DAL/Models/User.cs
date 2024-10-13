using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urban.DAL.Models
{
    public class User:UPCDefaultDate
    {
        [Key]
        public int User_Id { get; set; }
        public string Name { get; set; }
        public string Email  { get; set; }
        public string Password_hash { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }
        public string User_Type { get; set; }
        public string Profile_Picture { get; set; }         
        public ICollection<ServiceProviders> serviceProviders { get; set; }
    }
}
