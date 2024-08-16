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
        [Test]
        public void Counting()
        {
            var testPageString = ".NET test .NET";
            var expectedValue = 2;
            var result = _httpClient.CountNetOnPage(testPageString, "https://test.com");

            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }

}