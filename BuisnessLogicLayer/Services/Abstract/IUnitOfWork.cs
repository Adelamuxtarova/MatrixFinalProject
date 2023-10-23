using BuisnessLogicLayer;
using BuisnessLogicLayer.Services.Abstract;
using HotelReservationProject.Services.Abstractions;

namespace FinalProject.Services.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IReservationService ReservationService { get; }
        IBranchService BranchService { get; }
        IAdvertisementService AdvertisementService { get; }
        void Commit();
    }
}
