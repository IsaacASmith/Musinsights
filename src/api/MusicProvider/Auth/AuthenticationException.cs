using System;

namespace MusicProvider.Auth
{
    public class InvalidAuthenticationException : Exception
    {
        public InvalidAuthenticationException(string message = "") : base(message) { }
    }

    public class FailedAuthenticationException : Exception
    {
        public FailedAuthenticationException(string message = "") : base(message) { }
    }
}
