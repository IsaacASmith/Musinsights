using UseCases.Enums;

namespace MusicProvider.Spotify
{
    public static class SpotifyTimeRangeHelper
    {
        public static string GetTimeRangeString(TimeRange timeRange)
        {
            if (timeRange == TimeRange.LongTerm)
            {
                return "long_term";
            }
            else if (timeRange == TimeRange.MediumTerm)
            {
                return "medium_term";
            }
            else
            {
                return "short_term";
            }
        }
    }
}
