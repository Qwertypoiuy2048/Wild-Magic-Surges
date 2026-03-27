// =========================
// Surge Table
// =========================
class SurgeTable
{
    private List<Surge> _surges;
    private DiceRoller _dice;
    private Constant _default;

    public SurgeTable(List<Surge> surges)
    {
        _surges = surges;
        _dice = new DiceRoller();
        _default = new Constant(0, 'B', 1, "No surges were found. Please try again.");

    }

    public Surge GetSurge()
    {
        int index = _dice.Select(_surges.Count);
        return _surges[index];
    }

    public List<Surge> FilterSurge(List<char> types, List<int> powers)
    {
        List<Surge> result = new List<Surge>();

        foreach (Surge surge in _surges)
        {
            if ((types.Count == 0 || types.Contains(surge.Type())) &&
                (powers.Count == 0 || powers.Contains(surge.Power())))
            {
                result.Add(surge);
            }
        }

        return result;
    }
    public Surge GetSurgeById(int id)
    {
        foreach (Surge surge in _surges)
        {
            if (surge.Id() == id) return surge;
        }
        return _default;
    }
}
