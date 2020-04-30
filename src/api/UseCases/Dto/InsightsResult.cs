using System.Collections;
using System.Collections.Generic;
using UseCases.Enums;

namespace UseCases.Dto
{
    public class InsightsResult : BaseUseCaseResult
    {
        public IList<InsightForTimeRange> Insights { get; set; } = new List<InsightForTimeRange>();
    }

    public class InsightForTimeRange
    {
        public TimeRange TimeRange { get; set; }
        public int DiversityScore { get; set; }
        public int MainstreamScore { get; set; }
        public int DanceabilityScore { get; set; }
        public int EnergyScore { get; set; }
        public int PositivityScore { get; set; }
        public int ExplicitScore { get; internal set; }

        public IEnumerable<string> TopTracks { get; set; }
        public IEnumerable<string> TopGenres { get; set; }
        public IEnumerable<string> TopArtists { get; set; }
        public Dictionary<int, int> TrackDecadeCounts { get; set; }
    }
}
