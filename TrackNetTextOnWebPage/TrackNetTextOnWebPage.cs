using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace TrackNetTextOnWebPage;

internal class TrackNetTextOnWebPage
{
    public static void Main(string[] args)
    {
        object data = new object[]
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
        var webload = new Thread(new ParameterizedThreadStart(GetHtmlFile!));
        webload.Start(data);
        Thread.Sleep(5000);
    }
    private static async void GetHtmlFile(object data)
    {
        Array? urls;
        urls = (Array)data;

        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        foreach (var url in urls)
        {
            var s = url.ToString();
            try
            {
                await ProcessRepositoriesAsync(client, s);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
    private static async Task ProcessRepositoriesAsync(HttpClient client, string? url)
    {
        var json = await client.GetStringAsync(url);
        CountNetOnPage(json);
    }
    private static void CountNetOnPage(string page)
    {
        var resultOfOCuting = Regex.Matches(page, ".NET").Count;
        Console.WriteLine(resultOfOCuting);
    }
}

