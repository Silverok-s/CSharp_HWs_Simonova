Unit unit = new Unit("Голем", 250, 20);

int baseDamage = 60;

Console.WriteLine("=== Проверка системы урона ===\n");

DamageSystem physicalSystem = new DamageSystem(
    new PhysicalDamageCalculator()
);

Console.WriteLine("Физический урон:");
physicalSystem.ApplyDamage(unit, baseDamage);

DamageSystem magicSystem = new DamageSystem(
    new MagicDamageCalculator()
);

Console.WriteLine("\nМагический урон:");
magicSystem.ApplyDamage(unit, baseDamage);

DamageSystem fireSystem = new DamageSystem(
    new FireDamageCalculator()
);

Console.WriteLine("\nОгненный урон:");
fireSystem.ApplyDamage(unit, baseDamage);

Console.WriteLine($"\nИтоговое HP юнита: {unit.HP}");

// Для добавления ледяного урона достаточно создать
// новый класс IceDamageCalculator, реализующий
// интерфейс IDamageCalculator.
// Класс DamageSystem изменять не потребуется.
