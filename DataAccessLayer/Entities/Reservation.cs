using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }

        [Required(ErrorMessage = "Date To is required.")]
        public DateTime DateTo { get; set; }

        [Required(ErrorMessage = "Total Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Total Price must be a positive value.")]
        public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; }
        public int CustomerId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
