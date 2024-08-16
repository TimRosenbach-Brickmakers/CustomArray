// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using static System.Net.Http.Json.HttpClientJsonExtensions;

namespace AufgabeUrlsAuslesen;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var httpReader = new HttpReaderClass();

        await httpReader.ProcessRepositoriesAsync();

        Console.WriteLine("Hello");
    }
}

public class HttpReaderClass
{
    private readonly HttpClient _client = new();

    private readonly string[] _urls = new[]
    {
        "https://learn.microsoft.com",
        "https://learn.microsoft.com/aspnet/core",
        "https://learn.microsoft.com/azure",
        "https://learn.microsoft.com/azure/devops",
        "https://learn.microsoft.com/dotnet",
        "https://learn.microsoft.com/dotnet/desktop/wpf/get-started/create-app-visual-studio",
        "https://learn.microsoft.com/education",
        "https://learn.microsoft.com/shows/net-core-101/what-is-net",
        "https://learn.microsoft.com/enterprise-mobility-security",
        "https://learn.microsoft.com/gaming",
        "https://learn.microsoft.com/graph",
        "https://learn.microsoft.com/microsoft-365",
        "https://learn.microsoft.com/office",
        "https://learn.microsoft.com/powershell",
        "https://learn.microsoft.com/sql",
        "https://learn.microsoft.com/surface",
        "https://dotnetfoundation.org",
        "https://learn.microsoft.com/visualstudio",
        "https://learn.microsoft.com/windows",
        "https://learn.microsoft.com/maui"
    };

    public HttpReaderClass()
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
    }

    public async Task ProcessRepositoriesAsync()
    {
        foreach (var str in _urls)
        {
            try
            {
                var json = await _client.GetStringAsync(str);
                Console.WriteLine(json);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Url not working: " + str);
            }
        }
    }
}