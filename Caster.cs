// =========================
// Caster
// =========================
class Caster
{
    private int _triggerLevel;
    private DiceRoller _dice;

    public Caster()
    {
        _triggerLevel = 0;
        _dice = new DiceRoller();
    }

    public bool CastSpell(int level)
    {
        int roll = _dice.RollD20();
        int threshold = level + _triggerLevel;

        Console.WriteLine($"\nRoll: {roll}, Threshold: {threshold}");

        if (roll <= threshold)
        {
            Console.WriteLine("Surge triggered!");
            return true;
        }
        Console.WriteLine("No surge triggered");

        _triggerLevel += level;
        return false;
    }

    public void Reset()
    {
        _triggerLevel = 0;
    }
}
