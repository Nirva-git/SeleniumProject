using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using SeleniumNunitTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitTestProject.PageObjects
{
    internal class PracticeForm
    {
        public IWebDriver driver;
        public IJavaScriptExecutor js;

        public PracticeForm(IWebDriver driver, IJavaScriptExecutor js)
        {
            this.driver = driver;
            this.js = js;
            PageFactory.InitElements(driver, this);
        }
       
        //for click on form tab
        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(7) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > span:nth-child(1) > div:nth-child(1)")]
        private IWebElement formstab;
        //Practice form Button
        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(7) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(2) > ul:nth-child(1) > li:nth-child(1)")]
        private IWebElement practice;

        //for filling FirstName
        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement firstName;

        //for filling LastName
        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement lastName;

        //for filling Email
        [FindsBy(How = How.Id, Using = "userEmail")]
        private IWebElement email;

        //for radio button
        [FindsBy(How = How.CssSelector, Using = "label[for='gender-radio-1']")]
        private IWebElement gender;

        //for filling mobile number(10 digit)
        [FindsBy(How = How.Id, Using = "userNumber")]
        private IWebElement userNumber;

        ////for Date of Birth selector
        //[FindsBy(How = How.CssSelector, Using = "#dateOfBirthInput")]
        //private IWebElement doB;

       

        //for Hobies Checkbox
        [FindsBy(How = How.CssSelector, Using = "label[for='hobbies-checkbox-1']")]
        private IWebElement hobbies;

        //for Chooseing Picture from pc
        [FindsBy(How = How.CssSelector, Using = "#uploadPicture")]
        private IWebElement picture;

        //for Address
        [FindsBy(How = How.CssSelector, Using = "#currentAddress")]
        private IWebElement address;

        //for selecting State Dropdown 
        [FindsBy(How = How.CssSelector, Using = "#state")]
        private IWebElement state;

        //for selecting State Dropdown 
        [FindsBy(How = How.CssSelector, Using = ".css-1uccc91-singleValue")]
        private IWebElement stateInput;
        //for selecting city Dropdown 
        [FindsBy(How = How.CssSelector, Using = ".css-1wa3eu0-placeholder")]
        private IWebElement city;
        //for selecting city Dropdown 
        [FindsBy(How = How.CssSelector, Using = "#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(1) > span > div")]
        private IWebElement elements;

        //for clicking submit button
        [FindsBy(How = How.CssSelector, Using = "#submit")]
        private IWebElement submit;
        //for getting Text from Header
        [FindsBy(How = How.CssSelector, Using = "#example-modal-sizes-title-lg")]
        private IWebElement header;

        public void getFilledForm(string fname,string lname,string emailtext, string number)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //explicit wait for loading the page
            wait.Until(ExpectedConditions.ElementToBeClickable(formstab));
            formstab.Click();
            //explicit wait for loading the page
            wait.Until(ExpectedConditions.ElementToBeClickable(practice));
            practice.Click();

            //filling the details
            firstName.SendKeys(fname);
            lastName.SendKeys(lname);
            email.SendKeys(emailtext);
            gender.Click();
            userNumber.SendKeys(number);
            //waiting till element is clickable
            wait.Until(ExpectedConditions.ElementToBeClickable(elements));
            elements.Click();
             
            IWebElement pagescroll = scrolling();
            js.ExecuteScript("arguments[0].scrollIntoView(true);", pagescroll);
            // js.ExecuteScript("arguments[0].scrollIntoView(true);", widgets);
            // Explicit wait for loading the "widgets" element
        }
        //Dictionary<string, List<string>> StateInfo = new Dictionary<string, List<string>>() { "NC", new List<string>() { "jskj", "jsiwjisj" } };
        public void reamainingTask(string addressText)
         {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            hobbies.Click();
            address.SendKeys(addressText);
            picture.SendKeys(@"C:\Users\Paras\Pictures\siaram.jpeg");
            //state.Click();
            js.ExecuteScript("arguments[0].scrollIntoView(true);", submit);
            submit.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#example-modal-sizes-title-lg")));
            StringAssert.Contains("Thanks", header.Text.ToString());
            
        }
        public void StateDropdown(string stateName)
        {
            // Click on the state dropdown to open it


            state.Click();
            stateInput.SendKeys(stateName);

            // Locate and click the specific option within the dropdown
          //  var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
          //  var stateOption = driver.FindElement(By.XPath("//div[@class='css-1wa3eu0-menu']/div[text()='NCR']"));
           // wait.Until(ExpectedConditions.ElementToBeClickable(stateOption));
           // stateOption.Click();
          //  return state;
        }


        public void CityDropdown(string cityName)
        {
            // Click on the city dropdown to open it
            city.SendKeys(cityName);

            
        }

        public IWebElement scrolling()
        {
            return address;
            
        }
       

    }
}
