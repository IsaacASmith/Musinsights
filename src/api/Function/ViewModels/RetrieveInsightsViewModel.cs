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
        public int ObscurityScore { get; set; }
        public IEnumerable<string> TopGenres { get; set; }
        public IEnumerable<string> TopArtists { get; set; }

        public InsightsForRangeViewModel(InsightForTimeRange model)
        {
            TimeRange = model?.TimeRange.ToString();
            DiversityScore = model?.DiversityScore ?? 0;
            ObscurityScore = model?.ObscurityScore ?? 0;
            TopGenres = model?.TopGenres ?? new List<string>();
            TopArtists = model?.TopArtists ?? new List<string>();
        }
    }
}
