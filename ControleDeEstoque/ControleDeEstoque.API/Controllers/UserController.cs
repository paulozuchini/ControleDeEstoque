using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(CreateUserRequest model)
        {
            await _userService.AddUserAsync(model);
            return Ok(new { message = "User created" });
        }

        [HttpPut("{id, UpdateUserRequest}")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, UpdateUserRequest model)
        {
            await _userService.UpdateUserAsync(id, model);
            return Ok(new { message = "User updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok(new { message = "User deleted" });
        }
    }
}
