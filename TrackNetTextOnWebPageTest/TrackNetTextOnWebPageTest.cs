using TrackNetTextOnWebPage;
using Moq;

namespace TrackNetTextOnWebPageTest;

public class Tests
{
    private HttpReaderClass _httpClient;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpReaderClass();
    }

    public class GetPage : Tests
    {
        [Test]
        public void TestNoRespons()
        {

        }
    }

    public class Count : Tests
    {
        const string StringWithZeroDotNets = "<h1> hallo ich bin tim  </h1>";
        const string StringWithThreeDotNets = "<h1> .NET hallo ich bin tim .NET </h1>.NET";
        const string StringWithFourDotNets = "<h1> .NET hallo.NET ich bin tim .NET </h1>.NET";
        const string StringWithThreeDotNetsAndOneWrong = "<h1> .NET hallo./ET ich bin tim .NET </h1>.NET";

        [Test]
        [TestCase(StringWithZeroDotNets, 0)]
        [TestCase(StringWithThreeDotNets, 3)]
        [TestCase(StringWithFourDotNets, 4)]
        [TestCase(StringWithThreeDotNetsAndOneWrong, 3)]
        public void CountingOneLink(string page, int expectedValue)
        {
            var result = _httpClient.CountNetOnPage(page, "https://test.com");
            Assert.That(result, Is.EqualTo(expectedValue));
        }



    }

}