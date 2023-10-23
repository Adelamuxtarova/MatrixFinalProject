using AutoMapper;
using Azure;
using BuisnessLogicLayer.Models.Dtos;
using BuisnessLogicLayer.Response;
using BuisnessLogicLayer.Services.Abstract;
using DataAccessLayer.DAL;
using DataAccessLayer.Entities;
using DataAccessLayer.Validators;
using FinalProject.Services.Abstractions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace BuisnessLogicLayer.Services.Implement
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly ApplicationDbContext _context;
        public IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly IValidator<Advertisement> _validator;

        public AdvertisementService(IMapper mapper,
            IUnitOfWork unit,
            IValidator<Advertisement> validator,
            ApplicationDbContext context)
        {
            _mapper = mapper;
            _unit = unit;
            _validator = validator;
            _context = context;
        }

        public async Task<GenericResponse<bool>> AddAsync(AddAdvertismentDTO entity)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var advertisement = _mapper.Map<Advertisement>(entity);
                AdvertisementValidator validator = new AdvertisementValidator();
                var validationResult = await _validator.ValidateAsync(advertisement);
                if (!validationResult.IsValid)
                {
                    string result = validationResult.Errors.First().ErrorMessage;
                    _context.Advertisements?.AddAsync(advertisement);
                    _unit.Commit();
                }
                     response.Success(true, 200);
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }

        public async Task<GenericResponse<List<Advertisement>>> GetAll()
        {
            var response = new GenericResponse<List<Advertisement>>();
            try
            {
                var list = await _context.Advertisements.ToListAsync();
                response.Success(list, 200);
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }
        public async Task<GenericResponse<bool>> Update(UpdateAdvertismentDTO entity)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var convertedEntiry = _mapper.Map<Advertisement>(entity);
                var selectedAdvertisement = _context.Advertisements.FirstOrDefault(a => a.Id == entity.Id);
                if (selectedAdvertisement != null)
                {
                    _mapper.Map(entity, selectedAdvertisement);
                    _context.Advertisements.Update(selectedAdvertisement);
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
        public async Task<GenericResponse<bool>> Delete(int id)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var deletedEntity = _context.Advertisements.FirstOrDefault(e => e.Id == id);
                if (deletedEntity == null)
                {
                    response.Error(404, "This Advertisement is not found.");
                }
                else
                {
                    _context.Advertisements.Remove(deletedEntity);
                    _unit.Commit();
                    response.Success(true, 200);
                }
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }
    }
}
