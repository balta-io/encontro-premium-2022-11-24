using UtmBuilder.Exceptions;

namespace UtmBuilder.Tests;

[TestClass]
public class UtmTests
{
    [TestMethod]
    [ExpectedException(typeof(InvalidUtmException))]
    public void ShouldFailWhenUrlIsNotValid()
    {
        var utm = new Utm("invalid url", "source", "medium", "name");
        Assert.IsTrue(true);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidUtmException))]
    public void ShouldFailWhenSourceIsNotValid()
    {
        var utm = new Utm("https://balta.io", "", "medium", "name");
        Assert.IsTrue(true);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidUtmException))]
    public void ShouldFailWhenMediumIsNotValid()
    {
        var utm = new Utm("https://balta.io", "source", "", "name");
        Assert.IsTrue(true);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidUtmException))]
    public void ShouldFailWhenNameIsNotValid()
    {
        var utm = new Utm("https://balta.io", "source", "medium", "");
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void ShouldGenerateUtm()
    {
        var utm = new Utm("https://balta.io", "source", "medium", "name");
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void ShouldGenerateUtmLink()
    {
        var utm = new Utm(
            "https://balta.io",
            "source",
            "medium",
            "name",
            "id", "term",
            "content");
        Assert.AreEqual(
            utm.ToString(),
            "https://balta.io?utm_source=source&utm_medium=medium&utm_campaign=name&utm_id=id&utm_term=term&utm_content=content");
    }
}