public class AncientScroll : IUsableItem
{
    public string Name => "Древний свиток";
    public string Description => "Отнимает 20 HP и увеличивает урон на 30";
    public Rarity Rarity => global::Rarity.Legendary;

    public void Use(Player player)
    {
        player.HP = Math.Max(0, player.HP - 20);
        player.IncreaseDamage(30);

        Console.WriteLine("Вы использовали древний свиток!");
        Console.WriteLine("Потеряно 20 HP, урон увеличен на 30.");
    }
}