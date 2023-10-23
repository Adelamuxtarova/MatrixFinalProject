using BuisnessLogicLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.Entities;
using HotelReservationProject.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProjectMatrix.Controllers
{
    /// <summary>
    /// Controller for managing reservations.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        public ReservationController(ApplicationDbContext context,
            IReservationService reservationService)
        {
            _context = context;
            _reservationService = reservationService;
        }
        public ApplicationDbContext _context { get; }
        IReservationService _reservationService { get; }

        /// <summary>
        /// Creates a new reservation.
        /// </summary>
        /// <param name="ReservationInfo">The reservation information to add.</param>
        /// <returns>A response model containing the result of the reservation creation.</returns>
        [HttpPost]
        public async Task<IActionResult> AddReservation(ReservationDTO ReservationInfo)
        {
            var response = await _reservationService.Add(ReservationInfo);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Updates an existing reservation.
        /// </summary>
        /// <param name="UpdatedReservation">The updated reservation information.</param>
        /// <returns>A response model containing the result of the reservation update.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateReservation(ReservationUpdateDTO UpdatedReservation)
        {
            var response = await _reservationService.Update(UpdatedReservation);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Deletes a reservation by its ID.
        /// </summary>
        /// <param name="id">The ID of the reservation to delete.</param>
        /// <returns>A response model indicating the result of the reservation deletion.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var response = await _reservationService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Gets a list of all reservations.
        /// </summary>
        /// <returns>A response model containing the list of reservations.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var response = await _reservationService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

    }
}
