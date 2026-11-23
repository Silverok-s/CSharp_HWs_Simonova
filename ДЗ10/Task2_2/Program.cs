Player player = new Player("Кот", 100, 15);

List<IUsableItem> items = new List<IUsableItem>
{
    new HealthPotion(),
    new Sword(),
    new AncientScroll()
};

Console.WriteLine("=== Использование предметов ===");

foreach (IUsableItem item in items)
{
    Console.WriteLine($"\nПредмет: {item.Name}");
    Console.WriteLine($"Редкость: {item.Rarity}");
    Console.WriteLine($"Описание: {item.Description}");

    item.Use(player);
}

Console.WriteLine("\n=== Итоговые характеристики ===");
Console.WriteLine($"Имя: {player.Name}");
Console.WriteLine($"HP: {player.HP}");
Console.WriteLine($"Урон: {player.Damage}");
Console.WriteLine($"Состояние: {(player.HP > 0 ? "Жив" : "Мёртв")}");