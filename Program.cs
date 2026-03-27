class Program
{
    static void Main(string[] args)
    {
        Initialize Init = new Initialize();
        string path = Init.GetPath();
        int HistoryLength = Init.GetHistoryLength();

        CSVLoader loader = new CSVLoader();

        List<Surge> surges = loader.LoadCSV(path);

        SurgeTable table = new SurgeTable(surges);
        SurgeManager manager = new SurgeManager(table, HistoryLength);
        Caster caster = new Caster();
        Menu menu = new Menu(manager, caster);

        menu.StartMenu();
    }
}


/*
Status: Fully Functioning, Testing for bugs
$ Program - Functioning
$ Caster - Functioning
$ Constant -Functioning
* CSVLoader -Functioning
$ DiceRoller -Functioning
* Initialize - Functioning
* Menu -Functioning
$ Rollable - Functioning
$ Surge - Functioning
* SurgeManager - Functioning
* SurgeTable - Functioning
*/
