using BuisnessLogicLayer;
using BuisnessLogicLayer.Response;
using DataAccessLayer.Entities;

namespace HotelReservationProject.Services.Abstractions
{
    public interface IReservationService
    {
        Task<GenericResponse<List<Reservation>>> GetAll();
        Task<GenericResponse<bool>> Add(ReservationDTO entity);
        Task<GenericResponse<bool>> Update(ReservationUpdateDTO entity);
        Task<GenericResponse<bool>> Delete(int id);
    }
}
