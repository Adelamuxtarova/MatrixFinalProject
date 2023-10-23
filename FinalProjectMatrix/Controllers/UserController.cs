using BuisnessLogicLayer;
using BuisnessLogicLayer.Models.Dtos;
using BuisnessLogicLayer.Response;
using BuisnessLogicLayer.Services.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectMatrix.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;

        public UserController(IUserService service)
        {
            this.userService = service;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = userService.Authenticate(dto.Email, dto.Password);

            return Ok(new LoginResponseDto() { AccessToken = SecurityUtil.GenerateJwtToken(user) });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDTO UserInfo)
        {
            var response = await userService.Add(UserInfo);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Updates an existing User.
        /// </summary>
        /// <param name="NewUser">The updated User information.</param>
        /// <returns>A response model containing the result of the User update.</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO NewUser)
        {
            var response = await userService.Update(NewUser);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Deletes a User by its ID.
        /// </summary>
        /// <param name="id">The ID of the User to delete.</param>
        /// <returns>A response model indicating the result of the User deletion.</returns>
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var response = await userService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
