using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNunitTestProject.PageObjects
{
    internal class FirstPage
    {
        public IWebDriver driver;
        public IJavaScriptExecutor js;
        public FirstPage(IWebDriver driver, IJavaScriptExecutor js) 
        {
            this.driver = driver;
            this.js = js;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.ClassName, Using = "category-cards")]
        private IList<IWebElement> Allcards;
        [FindsBy(How = How.ClassName, Using = "category-cards")]
        private IWebElement cards;

        public PracticeForm getFormCard()
        {
            foreach(IWebElement card in Allcards)
            {
                string title = card.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[3]")).Text;
                if (title.Equals("Forms"))
                { 
                    card.Click();
                    return new PracticeForm(driver,js);
                }
            }
            return null;
        }
        public IWebElement viewCards()
        {
            return cards;
        }
       
    }
}
