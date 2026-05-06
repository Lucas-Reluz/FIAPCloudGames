using FIAPCloudGames.Application.DTOs;
using FIAPCloudGames.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAPCloudGames.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            _userService.Register(request.Name, request.Email, request.Password, request.IsAdmin);

            return Ok("Usuário criado com sucesso");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserRequest request)
        {
            _userService.Update(id, request.Name);

            return Ok("Usuário atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);

            return Ok("Usuário deletado com sucesso");
        }
    }
}
