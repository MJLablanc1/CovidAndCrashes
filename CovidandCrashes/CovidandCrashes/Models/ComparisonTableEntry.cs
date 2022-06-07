namespace CovidandCrashes.Models
{
    public class ComparisonTableEntry
    {
        // The main page will need a list of these entries, usually
        //     between date ranges and sorted by date optionally
        //     filtered by state and or crash type

        public DateOnly date { get; set; }
        public string? stateName { get; set; }
        public int covidDeaths { get; set; }
        public int crashDeaths { get; set; }

    }
}
