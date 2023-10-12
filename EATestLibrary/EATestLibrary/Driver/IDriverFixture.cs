using OpenQA.Selenium;

namespace EATestLibrary.Driver;

public interface IDriverFixture
{
    IWebDriver driver { get; }
}