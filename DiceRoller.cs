// =========================
// Dice Roller
// =========================
class DiceRoller
{
    private Random _random = new Random();

    public int RollD20()
    {
        return _random.Next(1, 21);
    }

    public int Roll(int num, int sides)
    {
        int total = 0;

        for (int i = 0; i < num; i++)
            total += _random.Next(1, sides + 1);

        return total;
    }

    public int Select(int max)
    {
        return _random.Next(max);
    }
}
