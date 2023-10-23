using BuisnessLogicLayer.Models.Dtos;
using BuisnessLogicLayer.Response;
using DataAccessLayer.Entities;

namespace BuisnessLogicLayer
{
    public interface IBranchService
    {
        Task<GenericResponse<List<Branch>>> GetAll();
        Task<GenericResponse<bool>> Add(BranchDTO BranchInfo);
        Task<GenericResponse<bool>> Update(UpdateBranchDTO UpdatedBranch);
        Task<GenericResponse<bool>> Delete(int id);
    }
}
