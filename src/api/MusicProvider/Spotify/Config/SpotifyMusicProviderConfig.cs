using System;

namespace MusicProvider.Spotify.Config
{
    public interface ISpotifyMusicProviderConfig
    {
        string ApiUrl { get; }
        string RecentlyPlayedRoute { get; }
        string MostPlayedArtistsRoute { get; }
    }

    public class SpotifyMusicProviderConfig : ISpotifyMusicProviderConfig
    {
        public string ApiUrl
        {
            get
            {
                return Environment.GetEnvironmentVariable("SpotifySettings:ApiUrl");
            }
        }

        public string RecentlyPlayedRoute
        {
            get
            {
                return Environment.GetEnvironmentVariable("SpotifySettings:RecentlyPlayedRoute");
            }
        }

        public string MostPlayedArtistsRoute
        {
            get
            {
                return Environment.GetEnvironmentVariable("SpotifySettings:MostPlayedArtistsRoute");
            }
        }
    }
}
