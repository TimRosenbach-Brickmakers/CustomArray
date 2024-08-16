using TrackNetTextOnWebPage;
using Moq;

namespace TrackNetTextOnWebPageTest;

public class Tests
{
    private HttpReader _httpReader;

    [SetUp]
    public void Setup()
    {
        _httpReader = new HttpReader();
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
            var result = _httpReader.CountNetOnPage(testPageString);

            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }

}