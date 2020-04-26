using Microsoft.Extensions.Logging;
using MusicProvider.ApiModels;
using MusicProvider.Auth;
using MusicProvider.Spotify.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.BusinessObjects;
using UseCases.Dto;
using UseCases.Enums;
using UseCases.Interfaces;

namespace MusicProvider.Spotify
{
    public class SpotifyArtistProvider : IArtistProvider
    {
        private readonly ISpotifyHttpClient _spotifyHttpClient;
        private readonly IAuthenticationManager _authManager;
        private readonly ILogger _logger;
        
        public SpotifyArtistProvider(ISpotifyHttpClient httpClient, 
                                     IAuthenticationManager authManager,
                                     ILogger<SpotifyArtistProvider> logger)
        {
            _spotifyHttpClient = httpClient;
            _authManager = authManager;
            _logger = logger;
        }

        public async Task<ProviderResult<IEnumerable<Artist>>> GetTopArtists(string userId, TimeRange timeRange)
        {
            try
            {
                var apiResponse = await _spotifyHttpClient.GetUserTopArtists(_authManager.GetAccessToken(userId), timeRange);

                if (apiResponse.Contains("\"status\": 401"))
                {
                    return new ProviderResult<IEnumerable<Artist>>
                    {
                        Success = false,
                        Message = "Failed to authenticate to spotify."
                    };
                }

                var artistsApiModel = JsonConvert.DeserializeObject<ArtistListResponseModel>(apiResponse);

                return new ProviderResult<IEnumerable<Artist>>
                {
                    Success = true,
                    Model = artistsApiModel.Items.Select(e => e.ToArtist())
                };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error contacting the spotify API");
                return new ProviderResult<IEnumerable<Artist>>
                {
                    Success = false,
                    Message = "Error contacting the spotify API"
                };
            }
        }
    }
}
