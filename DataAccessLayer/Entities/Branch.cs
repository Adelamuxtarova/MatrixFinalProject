using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataAccessLayer.Entities
{
    public class Branch
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [MaxLength(50, ErrorMessage = "User Name cannot exceed 50 characters.")]
        public string? BranchName { get; set; }
        public string? BranchsAddress { get; set; }

        [Required(ErrorMessage = "User Phone is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "User Phone must be a 10-digit number.")]
        public string? BranchPhone { get; set; }

    }
}
