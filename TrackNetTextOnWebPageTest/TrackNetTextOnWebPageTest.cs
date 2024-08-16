using TrackNetTextOnWebPage;
using Moq;
using RichardSzalay.MockHttp;

namespace TrackNetTextOnWebPageTest;

public class Tests
{
    public class Count : Tests
    {
        string url = "https://learn.microsoft.com/aspnet/core";

        const string StringWithZeroDotNets = "<h1> hallo ich bin tim  </h1>";
        const string StringWithThreeDotNets = "<h1> .NET hallo ich bin tim .NET </h1>.NET";
        const string StringWithFourDotNets = "<h1> .NET hallo.NET ich bin tim .NET </h1>.NET";
        const string StringWithThreeDotNetsAndOneWrong = "<h1> .NET hallo./ET ich bin tim .NET </h1>.NET";

        const string StringWithClassDotNet = "<h1 class='.NET'> .NET hallo ich bin tim .NET </h1>.NET";
        const string StringWithComplexHTMLCode = "<div> .NET .Ne T<h1 class='.NET'> .NET hallo ich bin tim </h1>.NET</div>";


        [Test]
        [TestCase(StringWithZeroDotNets, 0)]
        [TestCase(StringWithThreeDotNets, 3)]
        [TestCase(StringWithFourDotNets, 4)]
        [TestCase(StringWithThreeDotNetsAndOneWrong, 3)]
        [TestCase(StringWithClassDotNet, 3)]
        [TestCase(StringWithComplexHTMLCode, 3)]
        public async Task CountingOneLink(string page, int expectedValue)
        {
            MockHttpMessageHandler msgHandler = new();
            var httpClient = new HttpReaderClass(msgHandler.ToHttpClient());
            msgHandler.When(url).Respond("text/plain", page);

            var result = await httpClient.ProcessRepositoriesAsync(url);
            Assert.That(result, Is.EqualTo(expectedValue));
            msgHandler.Dispose();
        }

    }
}