using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer
{
    public class ReservationUpdateDTO
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal TotalPrice { get; set; }
        public string LastUpdatedById { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
    }
}
