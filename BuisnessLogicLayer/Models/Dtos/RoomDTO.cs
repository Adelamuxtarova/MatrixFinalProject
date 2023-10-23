using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer
{
    public class RoomUpdateDTO
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int RoomNumber { get; set; }
        public int RoomPrice { get; set; }
        public string Description { get; set; }
        public IFormFile file { get; set; }
    }
}
