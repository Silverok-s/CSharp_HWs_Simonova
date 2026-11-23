public class Unit
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int Armor { get; set; }

    public Unit(string name, int hp, int armor)
    {
        Name = name;
        HP = hp;
        Armor = armor;
    }
}
