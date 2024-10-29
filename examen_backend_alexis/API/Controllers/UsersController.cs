using examen_backend_alexis.API.Helpers;
using examen_backend_alexis.Application.Interfaces;
using examen_backend_alexis.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace examen_backend_alexis.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usuarioService;

        public UsersController(IUserService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usuarioService.GetAllAsync();
            return ResponseHandler.Success(users, "Users retrieved successfully", 200);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _usuarioService.GetByIdAsync(id);
            if (user == null)
                return ResponseHandler.Error("User not found", 404);

            return ResponseHandler.Success(user, "User retrieved successfully", 200);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            await _usuarioService.AddAsync(user);
            return ResponseHandler.Success(user, "User created successfully", 201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
                return ResponseHandler.Error("User ID mismatch", 400);

            await _usuarioService.UpdateAsync(user);
            var updatedUser = await _usuarioService.GetByIdAsync(id);

            if (updatedUser == null)
                return ResponseHandler.Error("User not found after update", 404);

            return ResponseHandler.Success<User>(updatedUser, "User updated successfully", 200);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _usuarioService.GetByIdAsync(id);
            if (user == null)
                return ResponseHandler.Error("User not found", 404);

            await _usuarioService.DeleteAsync(id);

            return ResponseHandler.Success<User>(user, "User deleted successfully", 200);
        }
    }
}
