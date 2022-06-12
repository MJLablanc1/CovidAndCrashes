namespace CovidandCrashes.Models
{
    public class CrashTypeDropdownEntry
    {
        // Main page uses a list of these to populate a dropdown list
        public int crashTypeID { get; set; }
        public string? crashTypeName { get; set; }
    }
}
