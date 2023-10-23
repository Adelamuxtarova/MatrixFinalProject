using BuisnessLogicLayer.Models.Dtos;
using BuisnessLogicLayer.Response;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Services.Abstract
{
    public interface ICustomerService
    {
        Task<GenericResponse<List<Customer>>> GetAll();
        Task<GenericResponse<bool>> Add(AddCustomerDTO BranchInfo);
        Task<GenericResponse<bool>> Update(UpdateCustomerDTO UpdatedBranch);
        Task<GenericResponse<bool>> Delete(int id);
    }
}
