using AutoMapper;
using BuisnessLogicLayer.Response;
using DataAccessLayer.DAL;
using DataAccessLayer.Entities;
using DataAccessLayer.Validators;
using FinalProject.Services.Abstractions;
using FluentValidation;
using HotelReservationProject.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BuisnessLogicLayer
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;
        public IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly IValidator<Reservation> _validator;
        public ReservationService(ApplicationDbContext context,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IValidator<Reservation> validator)
        {
            _context = context;
            _mapper = mapper;
            _unit = unitOfWork;
            _validator = validator;

        }

        public async Task<GenericResponse<List<Reservation>>> GetAll()
        {
            var response = new GenericResponse<List<Reservation>>();
            try
            {
                if (_context.Reservations.Any(r => r.IsDeleted == false)){
                   var result =  await _context.Reservations.ToListAsync();
                    response.Success(result, 200);
                }
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }
        public async Task<GenericResponse<bool>> Update(ReservationUpdateDTO UpdatedReservation)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var convertedEntity = _mapper.Map<Reservation>(UpdatedReservation);
                var selectedReservation = _context.Reservations.Find(convertedEntity.Id);
                if (selectedReservation != null)
                {
                    _context.Entry(selectedReservation).CurrentValues.SetValues(convertedEntity);
                    _context.SaveChanges();
                    response.Success(true, 200);
                }
                throw new ArgumentException("Data is not found");
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }
        public async Task<GenericResponse<bool>> Add(ReservationDTO ReservationInfo)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var reservation = _mapper.Map<Reservation>(ReservationInfo);
                ReservationValidator validator = new ReservationValidator();
                var validationResult = _validator.ValidateAsync(reservation);
                if (!validationResult.IsCompleted)
                {
                    var result = validationResult.ToString();
                    response.Error(400, result);
                }
                var user = _context.Users.Find(ReservationInfo.CreatedById);
                if (user == null)
                {
                    throw new ArgumentException("User not found");
                }
                var room = _context.Rooms.Find(ReservationInfo.RoomId);
                if (room == null)
                {
                    throw new ArgumentException("Room not found");
                }

                var customer = _context.Customers.Find(ReservationInfo.CustomerId);
                await _context.AddAsync(reservation);
                _unit.Commit();
                room.ReservationId = reservation.Id;
                _unit.Commit();
                response.Success(true, 200);
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }
        public async Task<GenericResponse<bool>> Delete(int id)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var reservation = _context.Reservations.Find(id);
                if (reservation == null)
                {
                    throw new ArgumentException("reservation not found");
                }
                reservation.IsDeleted = true;
                _unit.Commit();
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }
    }
}
