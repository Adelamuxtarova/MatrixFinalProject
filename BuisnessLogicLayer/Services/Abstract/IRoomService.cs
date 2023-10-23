using BuisnessLogicLayer.Response;
using DataAccessLayer.Entities;

namespace BuisnessLogicLayer
{
    public interface IRoomService
    {
        Task<GenericResponse<List<Room>>> GetAll();
        Task<GenericResponse<bool>> AddAsync(RoomAddDTO entity, string WebRootPat);
        Task<GenericResponse<bool>> Update(RoomUpdateDTO entity);
        Task<GenericResponse<bool>> Delete(int id);
    }
}
