using BuisnessLogicLayer;
using BuisnessLogicLayer.Services.Abstract;
using DataAccessLayer.DAL;
using FinalProject.Services.Abstractions;
using HotelReservationProject.Services.Abstractions;

namespace speedyStayBL.Services.Abstractions
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext Context;

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }
        public IReservationService ReservationService { get; }
        public IBranchService BranchService { get; }

        public IAdvertisementService AdvertisementService { get; }
        public void Commit()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

