// =========================
// Caster
// =========================
class Caster
{
    private int triggerLevel;
    private DiceRoller dice;

    public Caster()
    {
        triggerLevel = 0;
        dice = new DiceRoller();
    }

    public bool CastSpell(int level)
    {
        int roll = dice.RollD20();
        int threshold = level + triggerLevel;

        Console.WriteLine($"\nRoll: {roll}, Threshold: {threshold}");

        if (roll <= threshold)
        {
            Console.WriteLine("Surge triggered!");
            return true;
        }
        Console.WriteLine("No surge triggered");

        triggerLevel += level;
        return false;
    }

    public void Reset()
    {
        triggerLevel = 0;
    }
}
