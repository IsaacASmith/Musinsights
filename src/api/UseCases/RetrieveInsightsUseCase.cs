using System;
using System.Linq;
using System.Threading.Tasks;
using UseCases.BusinessObjects;
using UseCases.Dto;
using UseCases.Enums;
using UseCases.Interfaces;

namespace UseCases
{
    public interface IRetrieveInsightsUseCase
    {
        Task<InsightsResult> GetInsights(string userId);
    }

    public class RetrieveInsightsUseCase : IRetrieveInsightsUseCase
    {
        private readonly IArtistProvider _artistProvider;
        private readonly ITrackProvider _trackProvider;

        public RetrieveInsightsUseCase(IArtistProvider artistProvider, ITrackProvider trackProvider)
        {
            _artistProvider = artistProvider;
            _trackProvider = trackProvider;
        }

        public async Task<InsightsResult> GetInsights(string userId)
        {
            var result = new InsightsResult { Success = true };
            foreach(var timeRange in Enum.GetValues(typeof(TimeRange)).Cast<TimeRange>())
            {
                var topArtistsResult = await _artistProvider.GetTopArtists(userId, timeRange);
                if (!topArtistsResult.Success)
                {
                    return new InsightsResult { Success = false, Message = topArtistsResult.Message };
                }

                var topTracksResult = await _trackProvider.GetTopTracks(userId, timeRange);
                if (!topTracksResult.Success)
                {
                    return new InsightsResult { Success = false, Message = topTracksResult.Message };
                }

                var artistCorrelations = new ArtistCorrelations(topArtistsResult.Model);
                var artistPopularities = new ArtistPopularities(topArtistsResult.Model);
                var explicitScore = new ExplicitScore(topTracksResult.Model);

                var topGenres = new TopGenres(topArtistsResult.Model);

                result.Insights.Add(new InsightForTimeRange
                {
                    TimeRange = timeRange,
                    DiversityScore = 100 - artistCorrelations.TotalCorrelationScore,
                    MainstreamScore = artistPopularities.TotalPopularityScore,
                    ExplicitScore = explicitScore.ExplicitScoreValue,
                    TopTracks = topTracksResult.Model.Take(5).Select(e => e.Name),
                    TopArtists = topArtistsResult.Model.Take(5).Select(e => e.Name),
                    TopGenres = topGenres.GetTopGenres(),
                });
            }

            return result;
        }
    }
}
