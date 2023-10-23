using BuisnessLogicLayer.Models.Dtos;
using BuisnessLogicLayer.Response;
using DataAccessLayer.Entities;

namespace BuisnessLogicLayer.Services.Abstract
{
    public interface IAdvertisementService
    {
        Task<GenericResponse<List<Advertisement>>> GetAll();
        Task<GenericResponse<bool>> AddAsync(AddAdvertismentDTO entity);
        Task<GenericResponse<bool>> Update(UpdateAdvertismentDTO entity);
        Task<GenericResponse<bool>> Delete(int id);
    }
}
