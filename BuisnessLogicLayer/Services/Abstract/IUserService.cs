using BuisnessLogicLayer.Models.Dtos;
using BuisnessLogicLayer.Response;
using DataAccessLayer.Entities;

namespace BuisnessLogicLayer.Services.Abstract
{
    public interface IUserService
    {
        User Authenticate(string username,string password);
        Task<GenericResponse<bool>> Add(AddUserDTO UserInfo);
        Task<GenericResponse<bool>> Update(UpdateUserDTO UpdatedUser);
        Task<GenericResponse<bool>> Delete(string id);
    }
}
