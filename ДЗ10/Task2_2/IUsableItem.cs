public interface IUsableItem
{
    string Name { get; }
    string Description { get; }
    Rarity Rarity { get; }

    void Use(Player player);
}