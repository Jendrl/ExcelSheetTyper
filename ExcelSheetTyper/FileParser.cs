namespace ExcelSheetTyper
{
    public class FileParser
    {
        public List<NavisionEntry> ParseFile(string filename)
        {
            var fileLocation = @"C:\Repos\ExcelSheetTyper\test.csv";
            var line = "";
            var entries = new List<NavisionEntry>();
            using var fileStream = new FileStream(fileLocation, FileMode.Open);
            using var reader = new StreamReader(fileStream);
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                entries.Add(new(parts));
            }
            return entries;
        }
    }
}
