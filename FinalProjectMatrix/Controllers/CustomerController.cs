using BuisnessLogicLayer;
using BuisnessLogicLayer.Models.Dtos;
using BuisnessLogicLayer.Services.Abstract;
using BuisnessLogicLayer.Services.Implement;
using DataAccessLayer.DAL;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using System.Security.Claims;

namespace FinalProjectMatrix.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        public CustomerController(ICustomerService customerService, ApplicationDbContext context)
        {
            _customerService = customerService;
            _context = context;
        }
        ICustomerService _customerService;
       public ApplicationDbContext _context;

        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="customerInfo">The customer information to add.</param>
        /// <returns>A response model containing the result of the customer addition.</returns>

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerDTO CustomerInfo)
        {
            var response = await _customerService.Add(CustomerInfo);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Updates an existing Customer.
        /// </summary>
        /// <param name="NewCustomer">The updated Customer information.</param>
        /// <returns>A response model containing the result of the Customer update.</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDTO NewCustomer)
        {
            var response = await _customerService.Update(NewCustomer);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Deletes a Customer by its ID.
        /// </summary>
        /// <param name="id">The ID of the Customer to delete.</param>
        /// <returns>A response model indicating the result of the Customer deletion.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var response = await _customerService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Gets a list of all Customers.
        /// </summary>
        /// <returns>A response model containing the list of Customers.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var response = await _customerService.GetAll();
            return StatusCode(response.StatusCode, response);
        }
    }

}

