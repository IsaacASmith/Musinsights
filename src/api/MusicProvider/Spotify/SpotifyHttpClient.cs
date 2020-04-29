using MusicProvider.Spotify.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UseCases.Enums;

namespace MusicProvider.Spotify
{
    public interface ISpotifyHttpClient
    {
        Task<string> GetUserTopArtists(string accessToken, TimeRange timeRange = TimeRange.ShortTerm);
        Task<string> GetUserTopTracks(string accessToken, TimeRange timeRange = TimeRange.ShortTerm);
    }

    public class SpotifyHttpClient : ISpotifyHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ISpotifyMusicProviderConfig _config;

        public SpotifyHttpClient(HttpClient httpClient, ISpotifyMusicProviderConfig config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> GetUserTopArtists(string accessToken, TimeRange timeRange = TimeRange.ShortTerm)
        {
            return await GetPersonalizationInfo(accessToken, timeRange, "artists");
        }

        public async Task<string> GetUserTopTracks(string accessToken, TimeRange timeRange = TimeRange.ShortTerm)
        {
            return await GetPersonalizationInfo(accessToken, timeRange, "tracks");
        }

        private async Task<string> GetPersonalizationInfo(string accessToken, TimeRange timeRange, string personalizationType)
        {
            var reqUrl = $"{_config.ApiUrl}{_config.PersonalizationRoute}{personalizationType}?limit=50&time_range={SpotifyTimeRangeHelper.GetTimeRangeString(timeRange)}";

            var req = new HttpRequestMessage(HttpMethod.Get, reqUrl);
            req.Headers.Add("Authorization", $"Bearer {accessToken}");

            var response = await _httpClient.SendAsync(req);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
