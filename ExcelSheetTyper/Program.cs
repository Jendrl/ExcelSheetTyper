using WindowsInput;
using WindowsInput.Native;

namespace ExcelSheetTyper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputSimulator = new InputSimulator();
            var keyboardSimulator = new KeyboardSimulator(inputSimulator);
            var staggeredKeyboardSimulator = new StaggerKeyboardSimulator(keyboardSimulator, 50);
            var textTyper = new TextTyper(new StaggerKeyboardSimulator(keyboardSimulator, 10), new());
            var navisionTyper = new NavisionTyper(staggeredKeyboardSimulator, textTyper);

            var filePath = @"C:\Repos\ExcelSheetTyper\test.csv";
            var fileParser = new FileParser();
            var entries = fileParser.ParseFile(filePath);

            Task.Run(async () =>
            {
                await Task.Delay(5000);
                foreach (var item in entries)
                {
                    await navisionTyper.TypeEntryAsync(item);
                }
            });

            Console.ReadLine();
            Console.WriteLine("Done");
        }
    }
}
