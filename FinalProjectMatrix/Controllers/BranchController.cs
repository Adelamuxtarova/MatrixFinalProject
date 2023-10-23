using BuisnessLogicLayer;
using BuisnessLogicLayer.Models.Dtos;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectMatrix.Controllers
{
    /// <summary>
    /// Controller for managing branches.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BranchesController : ControllerBase
    {
        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        IBranchService _branchService;

        /// <summary>
        /// Adds a new branch.
        /// </summary>
        /// <param name="branchInfo">The branch information to add.</param>
        /// <returns>A response model containing the result of the branch addition.</returns>

        [HttpPost]
        public async Task<IActionResult> AddBranch(BranchDTO branchInfo)
        {
            var response = await _branchService.Add(branchInfo);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Updates an existing branch.
        /// </summary>
        /// <param name="NewBranch">The updated branch information.</param>
        /// <returns>A response model containing the result of the branch update.</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateBranch(UpdateBranchDTO NewBranch)
        {
            var response = await _branchService.Update(NewBranch);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Deletes a branch by its ID.
        /// </summary>
        /// <param name="id">The ID of the branch to delete.</param>
        /// <returns>A response model indicating the result of the branch deletion.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var response = await _branchService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Gets a list of all branches.
        /// </summary>
        /// <returns>A response model containing the list of branches.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            var response = await _branchService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

    }
}
