namespace ExcelSheetTyper
{
    public class NavisionEntry(string[] parts)
    {
        public string StartDate => parts[0];
        public string EndDate => parts[1];
        public string Action => parts[2];
    }
}
