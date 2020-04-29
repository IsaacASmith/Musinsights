using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MusicProvider.Auth;
using MusicProvider.Spotify;
using MusicProvider.Spotify.Config;
using UseCases;
using UseCases.Interfaces;

[assembly: FunctionsStartup(typeof(Functions.Startup))]
namespace Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();

            builder.Services.AddScoped<ISpotifyMusicProviderConfig, SpotifyMusicProviderConfig>();
            builder.Services.AddScoped<ISpotifyHttpClient, SpotifyHttpClient>();
            builder.Services.AddScoped<IArtistProvider, SpotifyArtistProvider>();
            builder.Services.AddScoped<ITrackProvider, SpotifyTrackProvider>();

            builder.Services.AddScoped<IRetrieveInsightsUseCase, RetrieveInsightsUseCase>();
        }
    }
}
