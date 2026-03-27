// =========================
// Rollable Surge
// =========================
using System.Text.RegularExpressions;

class Rollable : Surge
{
    private int _diceType;
    private int _diceNum;
    private int _bonus;
    private DiceRoller _dice;

    public Rollable(int id, char type, int power, string description,
                            int diceNum, int diceType, int bonus)
        : base(id, type, power, description)
    {
        _diceNum = diceNum;
        _diceType = diceType;
        _bonus = bonus;
        _dice = new DiceRoller();
    }

    public int Roll()
    {
        return _dice.Roll(_diceNum, _diceType) + _bonus;
    }

    public override void Display()
    {

        int result = Roll();

        string pattern = @"([0-9]+d[0-9]+)";
        string replacement = $"$1({result})";
        string Regexresult = Regex.Replace(_description, pattern, replacement);
        Console.WriteLine($"\nID: {_id}\nType: {_type}\nSeverity: {_power}\n{Regexresult}");

    }
}
