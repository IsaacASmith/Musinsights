﻿using Microsoft.Extensions.Logging;
using MusicProvider.ApiModels;
using MusicProvider.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.BusinessObjects;
using UseCases.Dto;
using UseCases.Enums;
using UseCases.Interfaces;

namespace MusicProvider.Spotify
{
    public class SpotifyTrackProvider : ITrackProvider
    {
        private readonly ISpotifyHttpClient _spotifyHttpClient;
        private readonly IAuthenticationManager _authManager;
        private readonly ILogger _logger;

        public SpotifyTrackProvider(ISpotifyHttpClient httpClient,
                                     IAuthenticationManager authManager,
                                     ILogger<SpotifyArtistProvider> logger)
        {
            _spotifyHttpClient = httpClient;
            _authManager = authManager;
            _logger = logger;
        }

        public async Task<ProviderResult<IEnumerable<Track>>> GetTopTracks(string userId, TimeRange timeRange)
        {
            try
            {
                var apiTrackResponse = await _spotifyHttpClient.GetUserTopTracks(_authManager.GetAccessToken(userId), timeRange);

                if (apiTrackResponse.Contains("\"status\": 401"))
                {
                    return new ProviderResult<IEnumerable<Track>>
                    {
                        Success = false,
                        Message = "Failed to authenticate to spotify."
                    };
                }

                var tracksApiModel = JsonConvert.DeserializeObject<TrackListResponseModel>(apiTrackResponse);

                var trackIds = string.Join(',', tracksApiModel.Items.Select(e => e.Id));

                var apiTrackFeaturesResponse = await _spotifyHttpClient.GetTrackAudioFeatures(_authManager.GetAccessToken(userId), trackIds);

                var trackFeaturesModel = JsonConvert.DeserializeObject<AudioFeaturesResponseModel>(apiTrackFeaturesResponse);

                return new ProviderResult<IEnumerable<Track>>
                {
                    Success = true,
                    Model = tracksApiModel.Items.Select(e =>
                    {
                        var track = e.ToTrack();
                        track.AudioFeatures = trackFeaturesModel.Audio_Features.FirstOrDefault(f => f.Id == track.Id)?.ToBusinessObject();
                        return track;
                    })
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error contacting the spotify API");
                return new ProviderResult<IEnumerable<Track>>
                {
                    Success = false,
                    Message = "Error contacting the spotify API"
                };
            }
        }
    }
}
