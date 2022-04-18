namespace SomeOfDemoTrash.Trashcan;

public class WeaponScroller
{
    private static readonly List<Weapon> _weapons = new() { new("1 - Gun"), new("2 - Automat"), new("3 - Shotgun"), new("4 - Bazooka") };
    private static Weapon _currentWeapon = _weapons.First();

    public static void ScrollingWithButtons()
    {
        while (true)
        {
            ConsoleKey key;

            var weapon = _weapons
                .Select((value, index) => (value, index))
                .FirstOrDefault(item => item.value.Id == _currentWeapon.Id);

            _currentWeapon = (key = Console.ReadKey(true).Key) switch
            {
                _ when key is ConsoleKey.DownArrow && weapon.index + 1 < _weapons.Count => _weapons[weapon.index + 1],
                _ when key is ConsoleKey.DownArrow => _weapons.First(),

                _ when key is ConsoleKey.UpArrow && weapon.index <= 0 => _weapons.Last(),
                _ when key is ConsoleKey.UpArrow => _weapons[weapon.index - 1],

                _ when key is ConsoleKey.D1 && _weapons.Count >= 1 => _weapons[0],
                _ when key is ConsoleKey.D2 && _weapons.Count >= 2 => _weapons[1],
                _ when key is ConsoleKey.D3 && _weapons.Count >= 3 => _weapons[2],
                _ when key is ConsoleKey.D4 && _weapons.Count >= 4 => _weapons[3],

                _ when key is ConsoleKey.Escape || key is ConsoleKey.Enter => throw new Exception("End of demo."),

                _ => _currentWeapon
            };

            Console.WriteLine(_currentWeapon.Name);
        }
    }

    private record Weapon
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; }

        public Weapon(string weaponName) => Name = weaponName;
    }
}