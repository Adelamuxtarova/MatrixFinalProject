using Microsoft.AspNetCore.Mvc;
using BuisnessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
    /// <summary>
    /// Controller for managing rooms.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RoomController : ControllerBase
    {
        public IWebHostEnvironment _hostEnvironment;
        private readonly IRoomService _roomService;
        public RoomController(IWebHostEnvironment hostEnvironment,
            IRoomService roomService)
        {
            _roomService = roomService;
            _hostEnvironment = hostEnvironment;
        }
        /// <summary>
        /// Creates a new room.
        /// </summary>
        /// <param name="addRoom">The room information to add.</param>
        /// <returns>A response model containing the result of the room creation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromForm] RoomAddDTO addRoom)
        {
            var response = await _roomService.AddAsync(addRoom, _hostEnvironment.WebRootPath);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Updates an existing room.
        /// </summary>
        /// <param name="EditedRoom">The updated room information.</param>
        /// <returns>A response model containing the result of the room update.</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateRoom([FromForm] RoomUpdateDTO EditedRoom)
        {
            var response = await _roomService.Update(EditedRoom);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Deletes a room by its ID.
        /// </summary>
        /// <param name="id">The ID of the room to delete.</param>
        /// <returns>A response model indicating the result of the room deletion.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var response = await _roomService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Gets a list of all rooms.
        /// </summary>
        /// <returns>A response model containing the list of rooms.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var response = await _roomService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

    }
}
