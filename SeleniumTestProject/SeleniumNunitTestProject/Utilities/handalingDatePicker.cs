using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitTestProject.Utilities
{
    public class handalingDatePicker
    {
        public IWebDriver driver;
        public IJavaScriptExecutor js;

        public handalingDatePicker(IWebDriver driver, IJavaScriptExecutor js)
        {
            this.driver = driver;
            this.js = js;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "#dateOfBirthInput")]
        private IWebElement doBPicker;

        [FindsBy(How = How.CssSelector, Using = "#dateOfBirth")]
        private IWebElement closePicker;
        public void clicckDate(string date)
        {
            

            // Wait for the input field to be clickable
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(doBPicker));

            // Type the date into the input field using SendKeys
            doBPicker.SendKeys(date);
            closePicker.Click();


        }
    }
}
