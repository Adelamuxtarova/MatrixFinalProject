using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Models.Dtos
{
    public class UpdateAdvertismentDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
    }
}
