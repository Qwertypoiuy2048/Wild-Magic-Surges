// =========================
// Console Menu
// =========================
using System.Reflection.Metadata;

class Menu
{
    private SurgeManager _manager;
    private Caster _caster;

    public Menu(SurgeManager manager, Caster caster)
    {
        _manager = manager;
        _caster = caster;
    }

    public void StartMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Cast spell");
            Console.WriteLine("2. Manual surge");
            Console.WriteLine("3. Reset cast spells");
            Console.WriteLine("4. View history");
            Console.WriteLine("5. Get surge by id");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    running = false;
                    break;
                case "1":
                    _manager.CheckHistory();
                    HandleCastSpell();
                    break;
                case "2":
                    _manager.CheckHistory();
                    HandleManualSurge();
                    break;
                case "3":
                    _caster.Reset();
                    Console.Clear();
                    Console.WriteLine("Cast spells reset.");
                    break;
                case "4":
                    _manager.DisplayHistory();
                    break;
                case "5":
                    HandleGetSurgeById();
                    break;
                default:
                    Console.WriteLine("Please enter a number on the list.");
                    break;
            }
        }
    }

    private void HandleCastSpell()
    {
        Console.Write("Enter spell level: ");
        string input = Console.ReadLine();
        int level;
        if (int.TryParse(input, out int Input)) { level = Input; } else { level = 1; }
        if (Input <= 0) { level = 1; }

        Console.Clear();

        bool triggered = _caster.CastSpell(level);

        if (triggered)
        {
            Surge surge = _manager.GetSurge();
            surge.Display();
            _caster.Reset();
        }
    }

    private void HandleManualSurge()
    {
        string input;
        List<char> types = new List<char>();
        List<int> powers = new List<int>();
        Console.Write("What Types? (B, V, H): ");
        input = Console.ReadLine();
        if (input != "")
        {
            types = input.ToUpper().ToCharArray().ToList();
        }
        else
        {
            types = new List<char> { 'B', 'V', 'H' };
        }

        Console.Write("What Powers? (1, 2, 3, 4): ");
        input = Console.ReadLine();
        if (!(input == ""))
        {
            powers = new List<int>();
            int powerTmp = 0;
            foreach (char power in input)
            {
                try
                {
                    powerTmp = int.Parse(power.ToString());
                }
                catch (Exception)
                {
                    powerTmp = 0;
                }
                finally
                {
                    powers.Add(powerTmp);
                }
            }

        }
        else
        {
            powers = new List<int> { 1, 2, 3, 4 };
        }

        Surge surge = _manager.GetFilteredSurge(types, powers);
        Console.Clear();
        surge.Display();
    }

    private void HandleGetSurgeById()
    {
        Console.Write("Enter id: ");
        string input = Console.ReadLine();
        int id = 0;
        try
        {
            id = int.Parse(input);
        }
        catch (Exception)
        {
            Console.WriteLine("Please enter a number.");
        }
        Surge surge = _manager.GetSurgeById(id);
        Console.Clear();
        surge.Display();
    }
}
