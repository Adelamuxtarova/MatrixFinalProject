using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Advertisement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100.")]
        public int Discount { get; set; }
    }
}
