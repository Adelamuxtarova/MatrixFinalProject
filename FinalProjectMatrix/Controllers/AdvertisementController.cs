using BuisnessLogicLayer;
using BuisnessLogicLayer.Models.Dtos;
using BuisnessLogicLayer.Services.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    /// <summary>
    /// Controller for managing user registration data.
    ///// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AdvertisementController : ControllerBase
    {
        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        IAdvertisementService _advertisementService;

        /// <summary>
        /// Adds a new registration entry.
        /// </summary>
        /// <param name="AdvertisementInfo">The Advertisement information to add.</param>
        /// <returns>A response model containing the result of the Advertisement addition.</returns>
        [HttpPost]
        public async Task<IActionResult> AddAdvertisement(BuisnessLogicLayer.AddAdvertismentDTO AdvertisementInfo)
        {
            var response = await _advertisementService.AddAsync(AdvertisementInfo);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Updates an existing Advertisement entry.
        /// </summary>
        /// <param name="NewAdvertisement">The updated Advertisement information.</param>
        /// <returns>A response model containing the result of the Advertisement update.</returns>

        [HttpPost]
        public async Task<IActionResult> UpdateAdvertisement(UpdateAdvertismentDTO NewAdvertisement)
        {
            var response = await _advertisementService.Update(NewAdvertisement);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Deletes a Advertisement entry by its ID.
        /// </summary>
        /// <param name="id">The ID of the Advertisement entry to delete.</param>
        /// <returns>A response model indicating the result of the Advertisement entry deletion.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAdvertisement(int id)
        {
            var response = await _advertisementService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Gets a list of all registration entries.
        /// </summary>
        /// <returns>A response model containing the list of Advertisement entries.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAdvertisements()
        {
            var response = await _advertisementService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

    }
}
