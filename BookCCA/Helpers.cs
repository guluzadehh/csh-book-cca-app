using Microsoft.Extensions.Configuration;

namespace BookCCA;

public static class Helpers
{
    public static string GetConnectionString(IConfiguration config, string name = "Default")
    {
        return config.GetConnectionString(name) ?? throw new NullReferenceException("Connection string is null");
    }
}
