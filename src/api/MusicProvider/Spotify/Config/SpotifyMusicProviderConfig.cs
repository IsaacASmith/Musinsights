using System;

namespace MusicProvider.Spotify.Config
{
    public interface ISpotifyMusicProviderConfig
    {
        string ApiUrl { get; }
        string PersonalizationRoute { get; }
        string AudioFeaturesRoute { get; }
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

        public string PersonalizationRoute
        {
            get
            {
                return Environment.GetEnvironmentVariable("SpotifySettings:PersonalizationRoute");
            }
        }

        public string AudioFeaturesRoute
        {
            get
            {
                return Environment.GetEnvironmentVariable("SpotifySettings:AudioFeaturesRoute");
            }
        }
    }
}
