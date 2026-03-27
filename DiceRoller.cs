// =========================
// Dice Roller
// =========================
class DiceRoller
{
    private Random random = new Random();

    public int RollD20()
    {
        return random.Next(1, 21);
    }

    public int Roll(int num, int sides)
    {
        int total = 0;

        for (int i = 0; i < num; i++)
            total += random.Next(1, sides + 1);

        return total;
    }

    public int Select(int max)
    {
        return random.Next(max);
    }
}
