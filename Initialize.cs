using System.Diagnostics;

class Initialize
{
    /*
    Initialize values like CSV location and number of possible surges by reading from a config file
    */
    private string _settingsFilePath = "C:\\Users\\ehcre\\.vscode\\projects\\CSE210\\CSE210-TR\\final\\FinalProject\\WMS_V2\\Settings.config";
    private string[] _lines;
    public Initialize()
    {
        _lines = File.ReadAllLines(_settingsFilePath);

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