using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EbaySandboxIntegration.Models
{
    public class OAuthApiResponse
    {
        [JsonProperty(PropertyName = "access_token")]
        public String AccessToken { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public String RefreshToken { get; set; }

        [JsonProperty(PropertyName = "refresh_token_expires_in")]
        public int RefreshTokenExpiresIn { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public String TokenType { get; set; }

        [JsonProperty(PropertyName = "errorMessage")]
        public String ErrorMessage { get; set; }
    }
}
