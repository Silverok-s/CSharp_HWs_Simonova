using System.Text.Json;

string path = Path.Combine(AppContext.BaseDirectory, "settings.json");

GameSettings settings;

if (File.Exists(path))
{
    string json = File.ReadAllText(path);
    settings = JsonSerializer.Deserialize<GameSettings>(json)
        ?? throw new Exception("Не удалось загрузить настройки.");
}
else
{
    Console.WriteLine("Файл настроек не найден. Создаём новые настройки.");

    Console.Write("Введите имя игрока: ");
    string playerName = Console.ReadLine() ?? "";

    int difficulty;
    do
    {
        Console.Write("Выберите сложность (1 - легко, 2 - нормально, 3 - сложно): ");
    }
    while (!int.TryParse(Console.ReadLine(), out difficulty)
           || difficulty < 1 || difficulty > 3);

    int musicVolume;
    do
    {
        Console.Write("Введите громкость музыки (0-100): ");
    }
    while (!int.TryParse(Console.ReadLine(), out musicVolume)
           || musicVolume < 0 || musicVolume > 100);

    settings = new GameSettings
    {
        PlayerName = playerName,
        Difficulty = difficulty,
        MusicVolume = musicVolume
    };

    var options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    string json = JsonSerializer.Serialize(settings, options);

    File.WriteAllText(path, json);

    Console.WriteLine("Настройки сохранены!");
}

Console.WriteLine("\n=== Настройки игры ===");
Console.WriteLine($"Имя игрока: {settings.PlayerName}");
Console.WriteLine($"Сложность: {settings.Difficulty}");
Console.WriteLine($"Громкость музыки: {settings.MusicVolume}");

public class GameSettings
{
    public string PlayerName { get; set; } = "";
    public int Difficulty { get; set; }
    public int MusicVolume { get; set; }
}
