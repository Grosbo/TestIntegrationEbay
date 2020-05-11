using System;

namespace EbaySandboxIntegration.Models
{
    public class OAuthResponse
    {
        public OAuthToken AccessToken { get; set; }
        public OAuthToken RefreshToken { get; set; }
        public String ErrorMessage { get; set; }
    }
}
