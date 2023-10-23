using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Models.Dtos
{
    public class UpdateBranchDTO
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string BranchsAddress { get; set; }
        public string BranchPhone { get; set; }
    }
}
