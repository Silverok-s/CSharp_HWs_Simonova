ICombatant knight = new Knight("Артур");
ICombatant mage = new Mage("Мерлин");

Console.WriteLine("=== Бой рыцаря и мага ===\n");

while (!knight.IsDead && !mage.IsDead)
{
    knight.Attack(mage);

    if (mage.IsDead)
    {
        break;
    }

    mage.Attack(knight);

    Console.WriteLine();
}

if (knight.IsDead)
{
    Console.WriteLine($"Победил Маг {mage.Name}!");
}
else
{
    Console.WriteLine($"Победил Рыцарь {knight.Name}!");
}

