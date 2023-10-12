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
    public class AutoSuggestionDropdown
    {
        public IWebDriver driver;
        public AutoSuggestionDropdown(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //for inputbased Subject Dropdown 
        [FindsBy(How = How.CssSelector, Using = ".subjects-auto-complete__value-container.subjects-auto-complete__value-container--is-multi.css-1hwfws3")]
        private IWebElement subject;

        //for inputbased Subject Dropdown 
        [FindsBy(How = How.CssSelector, Using = "#subjectsInput")]
        private IWebElement input;

        //for inputbased Subject Dropdown 
        [FindsBy(How = How.CssSelector, Using = ".subjects-auto-complete__indicators.css-1wy0on6")]
        private IList<IWebElement> options;

        public void selectOption(string subText, string FinalOption)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for the subject input container to be visible
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".subjects-auto-complete__value-container")));

            // Wait for the input field to be clickable
            // wait.Until(ExpectedConditions.ElementToBeClickable(input));

            // Scroll the input element into view
            // ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", input);
            subject.Click();
            // Send keys to the input field
            input.SendKeys(subText);

            // Wait for the options to be visible (assuming the options are dynamically loaded)
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".subjects-auto-complete__option")));

            // Click on the option with text "Maths"
            foreach (var option in options)
            {
                if (option.Text.Equals(FinalOption))
                {
                    option.Click();
                    break; // Exit the loop after clicking the desired option
                }
            }
        }


    }
}
