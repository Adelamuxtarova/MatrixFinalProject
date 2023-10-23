using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Models.Dtos
{
    public class AddUserDTO
    {
        public required string Password { get; set; }
        public required string UserName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Id { get; set;}
    }
}
