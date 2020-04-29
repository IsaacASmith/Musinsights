using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.Dto;
using UseCases.Enums;

namespace Function.ViewModels
{
    public class RetrieveInsightsViewModel
    {
        public IEnumerable<InsightsForRangeViewModel> Insights { get; set; }

        public RetrieveInsightsViewModel(InsightsResult model)
        {
            Insights = model.Insights.Select(e => new InsightsForRangeViewModel(e));
        }
    }

    public class InsightsForRangeViewModel
    {
        public string TimeRange { get; set; }
        public int DiversityScore { get; set; }
        public int MainstreamScore { get; set; }
        public int DanceabilityScore { get; set; }
        public int EnergyScore { get; set; }
        public int PositivityScore { get; set; }
        public int ExplicitScore { get; set; }

        public IEnumerable<string> TopTracks { get; set; }
        public IEnumerable<string> TopArtists { get; set; }
        public IEnumerable<string> TopGenres { get; set; }

        public InsightsForRangeViewModel(InsightForTimeRange model)
        {
            TimeRange = model?.TimeRange.ToString();
            DiversityScore = model?.DiversityScore ?? 0;
            MainstreamScore = model?.MainstreamScore ?? 0;
            PositivityScore = model?.PositivityScore ?? 0;
            DanceabilityScore = model?.DanceabilityScore ?? 0;
            EnergyScore = model?.EnergyScore ?? 0;
            ExplicitScore = model?.ExplicitScore ?? 0;
            TopTracks = model?.TopTracks ?? new List<string>();
            TopGenres = model?.TopGenres ?? new List<string>();
            TopArtists = model?.TopArtists ?? new List<string>();
        }
    }
}
