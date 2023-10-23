using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer
{
    public class AddAdvertismentDTO
    {

        public string? Description { get; set; }
        public int Discount { get; set; }

    }
}
