using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Models.Dtos
{
    public class UpdateCustomerDTO
    {
        public int Id {get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string UpdatedById { get; set; }
    }
}
