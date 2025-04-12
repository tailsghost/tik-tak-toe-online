namespace tik_tak_toe_server.Helpers;

public static class LoadEnv
{
    public static void Execute(string path)
    {
        if (!File.Exists(path)) return;

        var lines = File.ReadAllLines(path);

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if(string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

            var parts = line.Split('=',2);

            if (parts.Length != 2) continue;

            var key = parts[0].Trim();
            var value = parts[1].Trim();
            Environment.SetEnvironmentVariable(key,value);
        }
    }
}

