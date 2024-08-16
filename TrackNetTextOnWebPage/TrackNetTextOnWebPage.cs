using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace TrackNetTextOnWebPage;

internal static class TrackNetTextOnWebPage
{
    public static async Task Main(string[] args)
    {
        var httpReader = new HttpReaderClass();
        var amount = 0;
        var urls = new[]
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

        foreach (var url in urls)
        {
            var count = await httpReader.ProcessRepositoriesAsync(url);
            amount += count;
        }
        Console.WriteLine("Es wurde instgesamt " + amount + " mal .NET gefunden");

    }

}

public class HttpReaderClass
{
    private readonly HttpClient _client = new();

    public HttpReaderClass()
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
    }

    public async Task<int> ProcessRepositoriesAsync(string url)
    {
        try
        {
            var json = await _client.GetStringAsync(url);
            return CountNetOnPage(json, url);
        }
        catch (Exception e)
        {
            var json = "Url not working: " + url;
            Console.WriteLine(json);
        }

        return 0;
    }

    public int CountNetOnPage(string page, string url)
    {
        var resultOfCounting = Regex.Matches(page, ".NET").Count;
        Console.WriteLine(url + " : " + resultOfCounting );
        return resultOfCounting;
    }
}

