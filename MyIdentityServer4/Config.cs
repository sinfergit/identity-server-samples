using IdentityServer4.Models;

namespace IdentityServer4;

public class Config
{
    public static IEnumerable<ApiScope> GetAPIScopes()
    {
            return new List<ApiScope> 
            { 
                new ApiScope("api.read", "Friendly scope name") ,
                new ApiScope("api.write", "Friendly scope name") 
            };
    }
    
    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>()
        {
            new ApiResource("myapi","My API")
            {
                 Scopes = new List<string>(){"api.read","api.write"},
            }
        };
    }

    public static IEnumerable<Client> GetClients()
    {
        return new[]
        {
            new Client()
            {
                ClientId = "web_api_client_id",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("web_api_client_secret".Sha256())
                },
                AllowedScopes =
                {
                    "api.read","api.write"
                }
            }
        };
    }
}