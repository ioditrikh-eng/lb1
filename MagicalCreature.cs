public class MagicalCreature
{
    // Private fields
    private string _name;
    private string _species;
    private int _age;
    private double _magicPower;
    private MagicType _magicType;
    private bool _canFly;
    private DateTime _discoveryDate;
    private int _healthPoints;

    // Public properties with validation
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value.Length > 25)
                throw new ArgumentException("Name must be 2-25 characters long");
            if (!value.All(c => char.IsLetter(c) || c == ' ' || c == '-'))
                throw new ArgumentException("Name can only contain letters, spaces and hyphens");
            _name = value;
        }
    }

    public string Species
    {
        get => _species;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 30)
                throw new ArgumentException("Species must be 3-30 characters long");
            _species = value;
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value < 0 || value > 5000)
                throw new ArgumentException("Age must be between 0 and 5000 years");
            _age = value;
        }
    }

    public double MagicPower
    {
        get => _magicPower;
        set
        {
            if (value < 1 || value > 1000)
                throw new ArgumentException("Magic power must be between 1 and 1000");
            _magicPower = value;
        }
    }

    public MagicType MagicType { get => _magicType; set => _magicType = value; }

    public bool CanFly { get => _canFly; set => _canFly = value; }

    public DateTime DiscoveryDate
    {
        get => _discoveryDate;
        set
        {
            if (value < new DateTime(1000, 1, 1) || value > DateTime.Now)
                throw new ArgumentException("Discovery date must be between 01.01.1000 and current date");
            _discoveryDate = value;
        }
    }

    public int HealthPoints
    {
        get => _healthPoints;
        set
        {
            if (value < 1 || value > 500)
                throw new ArgumentException("Health points must be between 1 and 500");
            _healthPoints = value;
        }
    }

    // Constructor
    public MagicalCreature(string name, string species, int age, double magicPower, 
                          MagicType magicType, bool canFly, DateTime discoveryDate, int healthPoints)
    {
        Name = name;
        Species = species;
        Age = age;
        MagicPower = magicPower;
        MagicType = magicType;
        CanFly = canFly;
        DiscoveryDate = discoveryDate;
        HealthPoints = healthPoints;
    }

    // Methods demonstrating behavior
    public double CalculateBattlePower(int opponentLevel)
    {
        if (opponentLevel < 1 || opponentLevel > 100)
            throw new ArgumentException("Opponent level must be between 1 and 100");
        
        double typeBonus = MagicType == MagicType.Fire ? 1.2 : 1.0;
        double flightBonus = CanFly ? 1.15 : 1.0;
        
        return (MagicPower * typeBonus * flightBonus) / opponentLevel;
    }

    public string GetCreatureInfo()
    {
        return $"{Name} the {Species} ({MagicType}) - Power: {MagicPower}";
    }

    public bool IsAncient()
    {
        return Age >= 1000;
    }

    public void Train(double hours)
    {
        if (hours < 0.5 || hours > 24)
            throw new ArgumentException("Training must be between 0.5 and 24 hours");
        
        double powerIncrease = hours * (CanFly ? 2.5 : 2.0);
        MagicPower = Math.Min(1000, MagicPower + powerIncrease);
        
        Console.WriteLine($"{Name} trained for {hours} hours! Magic power increased to {MagicPower:F2}");
    }

    public void Heal(int healingPoints)
    {
        if (healingPoints < 1 || healingPoints > 100)
            throw new ArgumentException("Healing points must be between 1 and 100");
        
        HealthPoints = Math.Min(500, HealthPoints + healingPoints);
        Console.WriteLine($"{Name} healed {healingPoints} HP! Current HP: {HealthPoints}");
    }

    public void Evolve()
    {
        if (Age < 100)
        {
            Console.WriteLine($"{Name} is too young to evolve!");
            return;
        }

        MagicPower *= 1.3;
        HealthPoints = (int)(HealthPoints * 1.2);
        Console.WriteLine($"{Name} evolved! New power: {MagicPower:F2}, New HP: {HealthPoints}");
    }
}