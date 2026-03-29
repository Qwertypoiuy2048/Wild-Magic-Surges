using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;

class CSVLoader
{
    private string[] _lines = new string[0];
    private int _id = 0;
    private char _type = 'B';
    private int _power = 0;
    private string _description = "";
    private string[] _values = new string[0];
    private List<Surge> _surges = new List<Surge>();


    private void CreateLines(string path)
    {
        if (File.Exists(path))
        {
            _lines = File.ReadAllLines(path);
            Console.WriteLine("Using file at path: " + path);
        }
        else
        {
            Console.WriteLine("No file found at path: " + path + "\nUsing embedded file: Wild-Magic-Surges.tWMS.csv\n");

            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("Wild-Magic-Surges.tWMS.csv");
            using var reader = new StreamReader(stream);
            string file = reader.ReadToEnd();
            _lines = file.Split('\n');
        }
    }

    public List<Surge> LoadCSV(string path)
    {
        // TODO: Read file and create Surge objects
        CreateLines(path);
        foreach (string line in _lines)
        {

            _id++;
            _values = line.Split(',');
            _type = char.Parse(_values[0]);
            _power = int.Parse(_values[1]);
            _description = _values[2];

            bool isrollable = Regex.IsMatch(_description, "[0-9]+d[0-9]+");
            if (isrollable)
            {
                string pattern = @"([0-9]+d[0-9]+)"; // Capture the part you want to keep
                int diceNum = int.Parse(Regex.Match(_description, pattern).Groups[1].Value.Split('d')[0]);
                int diceType = int.Parse(Regex.Match(_description, pattern).Groups[1].Value.Split('d')[1]);

                Rollable surge = new Rollable(_id, _type, _power, _description, diceNum, diceType, 0);
                _surges.Add(surge);

            }
            else
            {
                Constant surge = new Constant(_id, _type, _power, _description);
                _surges.Add(surge);
            }
        }
        Console.WriteLine("Loaded " + _surges.Count + " surges.");
        return _surges;
    }
}