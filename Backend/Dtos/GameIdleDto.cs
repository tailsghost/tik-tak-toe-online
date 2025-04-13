using tik_tak_toe_server.Database.Entities;

namespace tik_tak_toe_server.Dtos;

public class GameIdleDto
{
    public Guid Id { get; set; }
    public UserDto Creator { get; set; }
    public GameStatus Status { get; set; }
}

