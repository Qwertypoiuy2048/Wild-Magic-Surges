// =========================
// Surge Manager
// =========================
using System.Reflection.Metadata;

class SurgeManager
{
    private SurgeTable _surges;
    private List<Surge> _history;
    private List<char> _types;
    private List<int> _powers;
    private Constant _default;
    private int _historyLength;
    Random _rand = new Random();

    public SurgeManager(SurgeTable table, int historyLength)
    {
        _surges = table;
        _history = new List<Surge>();
        _types = new List<char> { 'B', 'V', 'H' };
        _powers = new List<int> { 1, 2, 3, 4 };
        _default = new Constant(0, 'B', 1, "No surges were found. Please try again.");
        _historyLength = historyLength;
    }

    public Surge GetSurge()
    {
        Surge surge = _surges.GetSurge();
        if (surge == null) return _default;
        if (_history.Contains(surge)) return GetSurge();

        surge.DisplayDetails();
        if (Console.ReadLine() != "") return GetSurge();

        _history.Add(surge);
        return surge;
    }

    public Surge GetFilteredSurge(List<char> types, List<int> powers)
    {
        List<Surge> filtered = _surges.FilterSurge(types, powers);
        Surge selectedSurge = GetSurgeFromList(filtered);
        return selectedSurge;
    }

    public Surge GetSurgeFromList(List<Surge> surgesList)
    {
        if (surgesList.Count == 0) return _default;
        Surge selectedSurge = surgesList[_rand.Next(surgesList.Count)];

        if (_history.Contains(selectedSurge))
        {
            surgesList.Remove(selectedSurge); Console.WriteLine("Surge already used.");
            return GetSurgeFromList(surgesList);
        }

        selectedSurge.DisplayDetails();
        if (Console.ReadLine() != "") return GetSurgeFromList(surgesList);
        _history.Add(selectedSurge);

        return selectedSurge;
    }

    public void CheckHistory()
    {
        if (_history.Count > _historyLength) _history.RemoveAt(0);
    }

    public void DisplayHistory()
    {
        if (_history.Count == 0) { Console.WriteLine("History is empty."); return; }
        Console.Clear();
        Console.WriteLine("History:");
        foreach (Surge surge in _history) surge.Display();
    }

    public Surge GetSurgeById(int id)
    {
        Surge selectedSurge = _surges.GetSurgeById(id);
        return selectedSurge;
    }
}

