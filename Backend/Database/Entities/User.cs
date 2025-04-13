using System.ComponentModel.DataAnnotations;

namespace tik_tak_toe_server.Database.Entities;

public class User
{
    [Key] public Guid Id { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public double Rating { get; set; }

    public List<Game> Games { get; set; }

    public List<Game> WinnerGames { get; set; }

}

