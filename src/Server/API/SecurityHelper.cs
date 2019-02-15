using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace API
{
    public static class SecurityHelper
    {
        private static readonly IConfigurationManager<OpenIdConnectConfiguration> configurationManager;

        private static readonly string ISSUER = Env; // TODO - enter your Auth0 URL i.e. "https://wolftracker.auth0.com/"
        private static readonly string AUDIENCE = ""; // TODO - enter your audience here. i.e. "https://api.wolftracker.com"

        static SecurityHelper()
        {
            var documentRetriever = new HttpDocumentRetriever {RequireHttps = ISSUER.StartsWith("https://")};

            configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                $"{ISSUER}.well-known/openid-configuration",
                new OpenIdConnectConfigurationRetriever(),
                documentRetriever
            );
        }

        public static async Task<ClaimsPrincipal> ValidateTokenAsync(HttpRequest req)
        {
            req.Headers.TryGetValue("Authentication", out var headerValue);
            var value = headerValue.ToString();

            if (string.IsNullOrEmpty(value) || !value.Contains("Bearer"))
            {
                return null;
            }

            var config = await configurationManager.GetConfigurationAsync(CancellationToken.None);

            var validationParameter = new TokenValidationParameters
            {
                RequireSignedTokens = true,
                ValidAudience = AUDIENCE,
                ValidateAudience = true,
                ValidIssuer = ISSUER,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKeys = config.SigningKeys
            };

            ClaimsPrincipal result = null;
            var tries = 0;

            while (result == null && tries <= 1)
            {
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    result = handler.ValidateToken(value.Substring(7), validationParameter, out var token);
                }
                catch (SecurityTokenSignatureKeyNotFoundException)
                {
                    // This exception is thrown if the signature key of the JWT could not be found.
                    // This could be the case when the issuer changed its signing keys, so we trigger a 
                    // refresh and retry validation.
                    configurationManager.RequestRefresh();
                    tries++;
                }
                catch (SecurityTokenException)
                {
                    return null;
                }
            }

            return result;
        }
    }
}
