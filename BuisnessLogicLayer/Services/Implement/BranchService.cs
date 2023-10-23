using AutoMapper;
using BuisnessLogicLayer.Models.Dtos;
using BuisnessLogicLayer.Response;
using DataAccessLayer.DAL;
using DataAccessLayer.Entities;
using DataAccessLayer.Validators;
using DATAlayer.Validators;
using FinalProject.Services.Abstractions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BuisnessLogicLayer
{
    public class BranchService : IBranchService
    {
        private readonly ApplicationDbContext _context;
        public IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly IValidator<Branch> _validator;
        public BranchService(ApplicationDbContext context,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IValidator<Branch> validator)
        {
            _context = context;
            _mapper = mapper;
            _unit = unitOfWork;
            _validator = validator;

        }
        public async Task<GenericResponse<List<Branch>>> GetAll()
        {
            var response = new GenericResponse<List<Branch>>();
            try
            {
                var list = await _context.Branches.ToListAsync();
                response.Success(list, 200);
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }

        public async Task<GenericResponse<bool>> Add(BranchDTO BranchInfo)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var branch = _mapper.Map<Branch>(BranchInfo);
                BranchValidator validator = new BranchValidator();
                var validationResult = await _validator.ValidateAsync(branch);
                if (!validationResult.IsValid)
                {
                    var result = validationResult.Errors.ToString();
                }
                await _context.Branches.AddAsync(branch);
                _unit.Commit();
                response.Success(true, 200);
            }
            catch (Exception ex)
            {
                response.InternalError(ex.Message);
            }
            return response;
        }
        public async Task<GenericResponse<bool>> Update(UpdateBranchDTO UpdatedBranch)
        {
            var response = new GenericResponse<bool>();
            try
            {
                var convertedEntity = _mapper.Map<Branch>(UpdatedBranch);
                var selectedBranch = _context.Branches.Find(UpdatedBranch.Id);
                if (selectedBranch != null)
                {
                    var myNewBranchEntity = _mapper.Map(UpdatedBranch, selectedBranch);
                    _context.Branches.Update(myNewBranchEntity);
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
                var branch = _context.Branches.FirstOrDefault(b => b.Id == id);
                if (branch == null)
                {
                    throw new ArgumentException("Branch is not found");
                }
                _context.Branches.Remove(branch);
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
