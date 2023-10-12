using AngleSharp.Common;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitTestProject.Utilities
{
    public class GetDataFromModel
    {
        public IWebDriver driver;
        public GetDataFromModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //for TableRow
        //[FindsBy(How = How.CssSelector, Using = ".table-responsive tbody tr")]
        //private List<IWebElement> Rows;



        //for getting Text from Header
        //[FindsBy(How = How.CssSelector, Using = "#example-modal-sizes-title-lg")]
        //private IWebElement header;

        //public void gettingTitle()
        //{
        //    StringAssert.Contains("Thanks", header.Text.ToString());
        //}
        public List<List<string>> gettingData()
        {
            List<List<string>> tableData = new List<List<string>>();
           
            List<IWebElement> Rows = driver.FindElements(By.CssSelector(".table-responsive tbody tr")).ToList();
            foreach (IWebElement row in Rows)
            {
                var cells = row.FindElements(By.CssSelector("td"));
                List<string> rowData = new List<string>();

                foreach (var cell in cells)
                {
                    rowData.Add(cell.Text);
                }

                tableData.Add(rowData);
            }

            return tableData;
        }
    }
}
