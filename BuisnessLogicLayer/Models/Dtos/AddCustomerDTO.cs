using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Models.Dtos
{
    public class AddCustomerDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string CreatedById { get; set; }
    }
}
