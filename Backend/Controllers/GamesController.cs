using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tik_tak_toe_server.Database.Context;
using tik_tak_toe_server.Database.Entities;
using tik_tak_toe_server.Dtos;

namespace tik_tak_toe_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public GamesController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetGames()
        {
            var games = _context.Games
                .Include(u => u.Players)
                .Include(u => u.Winner)
                .ToListAsync();
            return Ok(games);
        }

        [HttpGet("idle")]
        public async Task<IActionResult> GetStatusGames()
        {
            var games = await _context.Games
                .Where(w => w.Status.Equals(GameStatus.Idle))
                .Include(u => u.Players)
                .Include(u => u.Winner)
                .ToListAsync();

            if (games == null)
                return NotFound("No games found");



            var dtos = new List<GameIdleDto>();

            for (var i = 0; i < games.Count; i++)
            {
                var game = games[i];
                dtos.Add(new GameIdleDto
                {
                    Id = game.Id,
                    Creator = new UserDto
                    {
                        Id = game.Players[i].Id,
                        Login = game.Players[i].Login,
                        Rating = game.Players[i].Rating
                    },
                    Status = game.Status
                });
            }

            return Ok(dtos);
        }
    }
}
