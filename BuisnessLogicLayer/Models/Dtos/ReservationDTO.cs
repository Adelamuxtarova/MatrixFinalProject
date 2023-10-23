using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer
{
    public class ReservationDTO
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public string CreatedById { get; set; }
        public int RoomId { get; set; }
    }
}
