using System.Collections.Generic;

namespace MusicProvider.Auth
{
    public interface IAuthenticationManager
    {
        void SetAccessToken(string userId, string accessToken);
        string GetAccessToken(string userId);
    }

    public class AuthenticationManager : IAuthenticationManager
    {
        private static Dictionary<string, string> _accessTokens { get; set; } = new Dictionary<string, string>();

        public string GetAccessToken(string userId)
        {
            if (!_accessTokens.ContainsKey(userId))
            {
                throw new InvalidAuthenticationException("Could not find an access token for the specified user.");
            }

            return _accessTokens[userId];
        }

        public void SetAccessToken(string userId, string accessToken)
        {
            _accessTokens[userId] = accessToken;
        }
    }
}
