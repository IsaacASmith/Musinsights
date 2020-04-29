using System;

namespace MusicProvider.Spotify.Config
{
    public interface ISpotifyMusicProviderConfig
    {
        string ApiUrl { get; }
        string PersonalizationRoute { get; }
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
    }
}
