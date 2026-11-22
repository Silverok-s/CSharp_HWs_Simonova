
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

Console.WriteLine("JSON");
Console.WriteLine(json);

GameCharacter? restored = JsonSerializer.Deserialize<GameCharacter>(json);

if (restored != null)
{
    Console.WriteLine("\nВосстановленный персонаж");
    Console.WriteLine($"Имя: {restored.Name}");
    Console.WriteLine($"Количество предметов: {restored.Inventory.Length}");
}

public class GameCharacter
{
    public string Name { get; set; } = "";
    public int Level { get; set; }
    public double Health { get; set; }
    public string[] Inventory { get; set; } = Array.Empty<string>();
}

