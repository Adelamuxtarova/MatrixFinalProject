using System;

namespace DataAccessLayer.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Reservation>? Reservations { get; set;}
        public List<Room>? Rooms { get; set;}
        public string UserId { get; set; }
        public User? User { get; set; }

    }
}
