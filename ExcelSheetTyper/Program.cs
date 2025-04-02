using WindowsInput;

namespace ExcelSheetTyper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputSimulator = new InputSimulator();
            var keyboardSimulator = new KeyboardSimulator(inputSimulator);
            var staggeredKeyboardSimulator = new StaggerKeyboardSimulator(keyboardSimulator, 1000);
            var textTyper = new TextTyper(new StaggerKeyboardSimulator(keyboardSimulator, 50), new());
            var navisionTyper = new NavisionTyper(staggeredKeyboardSimulator, textTyper);

            var filePath = @"C:\PKE\Utils\ExcelSheetTyper\navision.csv";
            var fileParser = new FileParser();
            var entries = fileParser.ParseFile(filePath);

            Task.Run(async () =>
            {
                Console.WriteLine("Starting in 5 seconds...");
                await Task.Delay(5000);
                Console.WriteLine($"Writing {entries.Count} entries");
                foreach (var item in entries)
                {
                    await navisionTyper.TypeEntryAsync(item);
                    Console.WriteLine($"Wrote entry {item.Date} - {item.StartTime} - {item.EndTime}");
                }
            });

            Console.ReadLine();
            Console.WriteLine("Done");
        }
    }
}
