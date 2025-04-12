using System.ComponentModel.DataAnnotations;

namespace tik_tak_toe_server.Database.Entities;

public class Game
{
    [Key] public Guid Id { get; set; }
    private string Name { get; set; }
}

