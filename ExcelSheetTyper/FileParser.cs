namespace ExcelSheetTyper
{
    public class FileParser
    {
        public List<NavisionEntry> ParseFile(string filePath)
        {
            var line = "";
            var entries = new List<NavisionEntry>();
            using var fileStream = new FileStream(filePath, FileMode.Open);
            using var reader = new StreamReader(fileStream);
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(';');
                entries.Add(new(parts));
            }
            return entries;
        }
    }
}
