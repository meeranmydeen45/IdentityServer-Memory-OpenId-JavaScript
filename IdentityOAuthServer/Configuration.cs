using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityOAuthServer
{
    public static class Configuration
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
           new IdentityResources.OpenId(),
           new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiResource> GetApisResource =>
        new List<ApiResource>
        {
          new ApiResource("apione")
          {
              Scopes = { "apione.read"}
          },
        };
        public static IEnumerable<ApiScope> GetApis =>
        new List<ApiScope>
        {
          new ApiScope("apione.read")
        };

        public static IEnumerable<Client> GetClients =>
        new List<Client>
        {
            //new Client
            //{
            //   ClientId = "mvc",
            //   AllowedGrantTypes = GrantTypes.Code,
            //   RedirectUris = { "https://localhost:5000/signin-oidc" },
            //   PostLogoutRedirectUris = { "https://localhost:5000/signout-callback-oidc" },
            //   ClientSecrets =
            //   {
            //       new Secret("secret".Sha256())
            //   },
            //   AllowedScopes = new List<string>
            //   {
            //        IdentityServerConstants.StandardScopes.OpenId,
            //        IdentityServerConstants.StandardScopes.Profile,
            //        "api1.read",
            //   }
            //},
            new Client
            {
               ClientId = "js_client",
               AllowedGrantTypes = GrantTypes.Implicit,
               RedirectUris = { "https://localhost:5045/Home/Sigin" },
               AllowedCorsOrigins = {"https://localhost:5045"},
               AllowedScopes = new List<string>
               {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "apione.read",
               },
               AllowAccessTokensViaBrowser = true,
               RequireConsent = false,
            }
        };   
    }
}
