using tik_tak_toe_server.Database.Entities;
using tik_tak_toe_server.Helpers;

namespace tik_tak_toe_server.Database.Context;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationContext context)
    {
        if (context.Users.Any())
        {
            return;
        }
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Login = "User 1", Rating = 1000, Password = ComputeSha512Hash.ComputeHash("1234")},
            new User { Id = Guid.NewGuid(), Login = "User 2", Rating = 900,Password = ComputeSha512Hash.ComputeHash("1234") }
        };

        var games = new List<Game>
        {
            new Game
            {
                Id = Guid.NewGuid(),
                Players = new List<User> { users[0], users[1] },
                Winner = users[0],
                Name = "Game 1",
                Status = GameStatus.Idle,
                WinnerId = users[0].Id,
                Field = new string[9],
            },
            new Game
            {
                Id = Guid.NewGuid(),
                Players = new List<User> { users[0], users[1] },
                Winner = users[1],
                Name = "Game 2",
                Status = GameStatus.Idle,
                WinnerId = users[1].Id,
                Field = new string[9],
            }
        };

        context.Users.AddRange(users);
        context.Games.AddRange(games);
        await context.SaveChangesAsync();
    }
}

