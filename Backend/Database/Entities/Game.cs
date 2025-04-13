using System.ComponentModel.DataAnnotations;

namespace tik_tak_toe_server.Database.Entities;

public class Game
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
    public GameStatus Status { get; set; }
    public List<User> Players { get; set; }
    public User? Winner { get; set; }
    public string[] Field { get; set; }
    public Guid? WinnerId { get; set; }
    public string? GameOverAt { get; set; }

}

public enum GameStatus
{
    Idle,
    InProgress,
    GameOver,
    GameOverDraw
}

