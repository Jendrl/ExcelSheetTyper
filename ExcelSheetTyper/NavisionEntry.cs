namespace ExcelSheetTyper
{
    public class NavisionEntry(string[] parts)
    {
        public string Date => parts[0];
        public string StartTime => parts[1];
        public string EndTime => parts[2];
        public string Action => parts[3];
    }
}
