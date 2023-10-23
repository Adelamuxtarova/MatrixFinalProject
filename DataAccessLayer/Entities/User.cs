using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class User 
    {
        public required string Id { get; set; } 
        public required string Password { get; set; }
        public required string UserName { get; set; } 
        public required string LastName { get; set; } 
        public required string Email { get; set; } 
        public string? PhoneNumber { get; set; } 

    }
}
