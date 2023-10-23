using AutoMapper;
using BuisnessLogicLayer.Response;
using DataAccessLayer.DAL;
using DataAccessLayer.Entities;
using DATAlayer.Validators;
using FinalProject.Services.Abstractions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuisnessLogicLayer
{
    public class RoomService : IRoomService
    {
        private readonly IValidator<Room> _validator;
        private readonly ApplicationDbContext _context;
        public IMapper _mapper;
        private readonly IUnitOfWork _unit;
        public RoomService(ApplicationDbContext context,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IValidator<Room> validator)
        {
            _context = context;
            _mapper = mapper;
            _unit = unitOfWork;
            _validator = validator;
        }
        public async Task<GenericResponse<bool>> AddAsync(RoomAddDTO addRoom, string WebRootPath)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var room = _mapper.Map<Room>(addRoom);
                RoomValidator validator = new RoomValidator();
                var validationResult = await _validator.ValidateAsync(room);
                if (!validationResult.IsValid)
                {
                    string result = validationResult.Errors.ToString();
                }
                var fileUniqueName = string.Concat(Guid.NewGuid().ToString(), addRoom.file.FileName);
                var folderPath = Path.Combine(WebRootPath, "Picture");
                var fullPath = Path.Combine(folderPath, fileUniqueName);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (FileStream fs = new FileStream(fullPath, FileMode.Create))
                {
                    addRoom.file.CopyTo(fs);
                }
                room.RoomImages = fileUniqueName;
                _context.Rooms.Add(room);
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
                var room = _context.Rooms.Find(id);
                if (room == null)
                {
                    throw new ArgumentException("Data is not found");
                }
                _context.Rooms.Remove(room);
                _unit.Commit();
                response.Success(true, 200);
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }
        public async Task<GenericResponse<bool>> Update(RoomUpdateDTO entity)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var convertedEntity = _mapper.Map<Room>(entity);
                var selectedRoom = _context.Rooms.Find(convertedEntity.RoomId);
                if (selectedRoom != null)
                {
                    var myNewRoomEntity = _mapper.Map(entity, selectedRoom);
                    _context.Rooms.Update(myNewRoomEntity);
                    _unit.Commit();
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
        public async Task<GenericResponse<List<Room>>> GetAll()
        {
            var response = new GenericResponse<List<Room>>();
            try
            {
                var list = await _context.Rooms.ToListAsync();
                response.Success(list, 200);
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }
    }
}
