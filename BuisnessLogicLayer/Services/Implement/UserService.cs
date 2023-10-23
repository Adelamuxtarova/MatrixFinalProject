using AutoMapper;
using BuisnessLogicLayer.Models.Dtos;
using BuisnessLogicLayer.Response;
using BuisnessLogicLayer.Services.Abstract;
using DataAccessLayer.DAL;
using DataAccessLayer.Entities;
using DATAlayer.Validators;
using FinalProject.Services.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Services.Implement
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly IValidator<User> _validator;
        public UserService(ApplicationDbContext context,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IValidator<User> validator)
        {
            _context = context;
            _mapper = mapper;
            _unit = unitOfWork;
            _validator = validator;

        }

        public User Authenticate(string email, string password)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    throw new Exception();
                }
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenericResponse<bool>> Add(AddUserDTO UserInfo)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var user = _mapper.Map<User>(UserInfo);
                UserValidator validator = new UserValidator();
                var validationResult = await _validator.ValidateAsync(user);
                if (!validationResult.IsValid)
                {
                    var result = validationResult.Errors.ToString();
                    response.Error(400 ,result);
                }
                await _context.Users.AddAsync(user);
                _unit.Commit();
                response.Success(true, 200);
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }
        public async Task<GenericResponse<bool>> Update(UpdateUserDTO UpdatedUser)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var convertedEntity = _mapper.Map<User>(UpdatedUser);
                var selectedUser = _context.Users.Find(UpdatedUser.Id);
                if (selectedUser != null)
                {
                    var myNewUserEntity = _mapper.Map(UpdatedUser, selectedUser);
                    _context.Users.Update(myNewUserEntity);
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
        public async Task<GenericResponse<bool>> Delete(string id)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var User = _context.Users.FirstOrDefault(b => b.Id == id);
                if (User == null)
                {
                    throw new ArgumentException("User is not found");
                }
                _context.Users.Remove(User);
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
