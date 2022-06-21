namespace CovidandCrashes.Models
{
    public class ComparisonTableEntry
    {
        // The main page will need a list of these entries, usually
        //     between date ranges and sorted by date optionally
        //     filtered by state and or crash type

        public string? stateName { get; set; }
        public string? crashType { get; set; }
        public string? intersectionType { get; set; }
        public int covidDeaths { get; set; }
        public int crashDeaths { get; set; }
        public DateTime date { get; set; }
        public string? dateShort { get; set; }

    }
}
