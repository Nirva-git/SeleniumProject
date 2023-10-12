using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using EATestLibrary.Config;
using EATestLibrary.Driver;

namespace EAApplication_Test
{
    public class UnitTest1: IDisposable
    {
        private IDriverFixture _driverFixture;
        
        public UnitTest1()
        {
            var testSettings = new TestSettings()
            {
                BrowserType = BrowserType.Chrome,
                ApplicationUrl = new Uri("http://www.localhost:8000"),
                TimeOutInterval = 30

            };
            _driverFixture = new DriverFixture(testSettings);
        }
        [Fact]
        public void Test1()
        {
           
            _driverFixture.driver.FindElement(By.LinkText("Product")).Click();

            _driverFixture.driver.FindElement(By.LinkText("Create")).Click();

        }

        public void Dispose()
        {
            _driverFixture.driver.Quit();
        }
    }
}