namespace CodeGymTests;

using CodeGym;

public class KataTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var kata = new Kata();

        Assert.That(kata.Solve(), Is.EqualTo(0));
    }
}