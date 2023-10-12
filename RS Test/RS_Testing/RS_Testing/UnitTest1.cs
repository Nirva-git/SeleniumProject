using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using WebDriverManager.DriverConfigs.Impl;

namespace RS_Testing
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver= new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void Test1()
        {
            //    IWebElement dropdown = driver.FindElement(By.Id("page-menu"));
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");

            ArrayList a = new ArrayList();
            IList<IWebElement> veggies = 
                driver.FindElements(By.XPath("//tbody/tr/td[1]"));
            foreach (IWebElement veggie in veggies)
            {
              a.Add(veggie.Text);

            }
            a.Sort();
            

            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();

            ArrayList b= new ArrayList();
            IList<IWebElement> SortedVeggies = driver.FindElements(By.XPath("//tbody/tr/td[1]"));
            foreach (IWebElement veggie in SortedVeggies)
            {
                b.Add(veggie.Text);
            }

            Assert.AreEqual(a, b);
        }
    }
}