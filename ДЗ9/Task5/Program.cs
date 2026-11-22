
using System.Text.Json;

GameCharacter character = new GameCharacter
{
    Name = "Alex",
    Level = 5,
    Health = 85.5,
    Inventory = new string[] { "Sword", "Shield", "Potion" }
};

var options = new JsonSerializerOptions
{
    WriteIndented = true
};

string json = JsonSerializer.Serialize(character, options);

string path = Path.Combine(AppContext.BaseDirectory, "save.json");

File.WriteAllText(path, json);

string loadedJson = File.ReadAllText(path);

GameCharacter? restored = JsonSerializer.Deserialize<GameCharacter>(loadedJson);

if (restored != null)
{
    Console.WriteLine("=== Загруженный персонаж ===");
    Console.WriteLine($"Имя: {restored.Name}");
    Console.WriteLine($"Уровень: {restored.Level}");
    Console.WriteLine($"Здоровье: {restored.Health}");
    Console.WriteLine($"Инвентарь: {string.Join(", ", restored.Inventory)}");
}

public class GameCharacter
{
    public string Name { get; set; } = "";
    public int Level { get; set; }
    public double Health { get; set; }
    public string[] Inventory { get; set; } = Array.Empty<string>();
}
