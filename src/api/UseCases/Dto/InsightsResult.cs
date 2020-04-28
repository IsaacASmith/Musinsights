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
        public int ObscurityScore { get; set; }

        public IEnumerable<string> TopGenres { get; set; }
        public IEnumerable<string> TopArtists { get; set; }
    }
}
