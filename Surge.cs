// =========================
// Abstract Surge
// =========================
abstract class Surge
{
    protected int _id;
    protected char _type;
    protected int _power;
    protected string _description;

    public Surge(int id, char type, int power, string description)
    {
        _id = id;
        _type = type;
        _power = power;
        _description = description;
    }

    public abstract void Display();
    public int Power()
    {
        return _power;
    }
    public char Type()
    {
        return _type;
    }
    public int Id()
    {
        return _id;
    }
    public void DisplayDetails()
    {
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine("Enter to continue, anything else to reroll");
    }
}