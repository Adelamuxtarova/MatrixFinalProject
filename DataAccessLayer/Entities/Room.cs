using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Room
    {
        public int RoomId { get; set; }

        [MaxLength(50, ErrorMessage = "Room Name cannot exceed 50 characters.")]
        [Required(ErrorMessage = "Room Name is required.")]
        public string? RoomName { get; set; }

        [Required(ErrorMessage = "Room Number is required.")]
        public int RoomNumber { get; set; }

        public string? RoomImages { get; set; }

        public int RoomPrice { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        public int? ReservationId { get; set; }
        public Reservation? Reservation { get; set; }

    }
}
