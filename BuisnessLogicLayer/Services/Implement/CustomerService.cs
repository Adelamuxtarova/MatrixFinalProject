using AutoMapper;
using BuisnessLogicLayer.Models.Dtos;
using BuisnessLogicLayer.Response;
using BuisnessLogicLayer.Services.Abstract;
using DataAccessLayer.DAL;
using DataAccessLayer.Entities;
using DataAccessLayer.Validators;
using DATAlayer.Validators;
using FinalProject.Services.Abstractions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Services.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        public IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly IValidator<Customer> _validator;
        public CustomerService(ApplicationDbContext context,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IValidator<Customer> validator)
        {
            _context = context;
            _mapper = mapper;
            _unit = unitOfWork;
            _validator = validator;

        }
        public async Task<GenericResponse<List<Customer>>> GetAll()
        {
            var response = new GenericResponse<List<Customer>>();
            try
            {
                var customers = await _context.Customers.ToListAsync();
                response.Success(customers, 200);
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }

        public async Task<GenericResponse<bool>> Add(AddCustomerDTO CustomerInfo)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(CustomerInfo);
                CustomerValidator validator = new CustomerValidator();
                var validationResult = await _validator.ValidateAsync(customer);
                if (!validationResult.IsValid)
                {
                    var result = validationResult.Errors.ToString();
                    response.Error(400,result);
                }
                await _context.Customers.AddAsync(customer);
                _unit.Commit();
                response.Success(true, 200);
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }
        public async Task<GenericResponse<bool>> Update(UpdateCustomerDTO UpdatedCustomer)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var convertedEntity = _mapper.Map<Customer>(UpdatedCustomer);
                var selectedCustomer = _context.Customers.Find(UpdatedCustomer.Id);
                if (selectedCustomer != null)
                {
                    var myNewCustomerEntity = _mapper.Map(UpdatedCustomer, selectedCustomer);
                    _context.Customers.Update(myNewCustomerEntity);
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
                var customer = _context.Customers.FirstOrDefault(b => b.Id == id);
                if (customer == null)
                {
                    throw new ArgumentException("User is not found");
                }
                _context.Customers.Remove(customer);
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
