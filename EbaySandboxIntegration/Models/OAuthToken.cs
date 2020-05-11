using System;

namespace EbaySandboxIntegration.Models
{
    public class OAuthToken
    {
        public String Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public TokenType TokenType { get; set; }
    }
}
