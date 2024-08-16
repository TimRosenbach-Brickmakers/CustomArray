



namespace AufgabeUrlsAuslesenTests;

using static HttpClient;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        HttpClient client = new();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}