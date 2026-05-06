using FIAPCloudGames.Application.DTOs;
using FIAPCloudGames.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAPCloudGames.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        private readonly GamesService _service;

        public GamesController(GamesService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] CreateGameRequest request)
        {
            _service.Create(request.Name, request.Description, request.Genre, request.Price);

            return Ok("Jogo criado com sucesso");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, [FromBody] UpdateGameRequest request)
        {
            _service.Update(id, request.Name, request.Description, request.Genre, request.Price);

            return Ok("Jogo atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);

            return Ok("Jogo deletado com sucesso");
        }

        [HttpGet("by-name")]
        [Authorize]
        public IActionResult GetByName([FromQuery] string name)
        {
            var game = _service.GetByName(name);

            return Ok(game);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var games = _service.GetAll();

            return Ok(games);
        }
    }
}
