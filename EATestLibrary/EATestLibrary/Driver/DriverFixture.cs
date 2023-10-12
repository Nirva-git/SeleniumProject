using EATestLibrary.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace EATestLibrary.Driver;

public class DriverFixture : IDriverFixture
{
    private readonly TestSettings _testSettings;
    public IWebDriver driver { get; }

    public DriverFixture(TestSettings testSettings)
    {
        _testSettings = testSettings;
        driver = GetWebDriver();
        driver.Navigate().GoToUrl(_testSettings.ApplicationUrl);

    }
    private IWebDriver GetWebDriver()
    {
        return _testSettings.BrowserType switch
        {
            BrowserType.Chrome => new ChromeDriver(),
            BrowserType.Safari => new SafariDriver(),
            BrowserType.FireFox => new FirefoxDriver(),
            BrowserType.EdgeChromium => new EdgeDriver(),
            _ => new ChromeDriver()
        };
    }
}

public enum BrowserType
{
    Chrome,
    FireFox,
    Safari,
    EdgeChromium
}