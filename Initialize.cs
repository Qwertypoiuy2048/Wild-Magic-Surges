using System.Diagnostics;
using System.Reflection;


class Initialize
{
    /*
    Initialize values like CSV location and number of possible surges by reading from a config file
    */


    

    private string _settingsFilePath = "Settings.config";
    private string[] _lines;
    public Initialize()
    {
        if (File.Exists(_settingsFilePath))
        {
            _lines = File.ReadAllLines(_settingsFilePath);
            Console.WriteLine("Using file at path: " + _settingsFilePath);
        }
        else
        {
            Console.WriteLine("No file found at path: " + _settingsFilePath + "\nUsing embedded file: Wild-Magic-Surges.Settings.config\n");

            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("Wild-Magic-Surges.Settings.config");
            using var reader = new StreamReader(stream);
            string file = reader.ReadToEnd();
            _lines = file.Split('\n');
        }
    }
    public string GetPath()
    {
        Console.WriteLine("\nPath: " + _lines[0]);
        return _lines[0];
    }
    public int GetHistoryLength()
    {
        Console.WriteLine("History Length: " + _lines[1]);
        return int.Parse(_lines[1]);
    }
}