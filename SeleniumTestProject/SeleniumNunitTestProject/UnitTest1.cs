using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumNunitTestProject.PageObjects;
using SeleniumNunitTestProject.Utilities;
using System.Data;

namespace SeleniumNunitTestProject
{
    public class Test : Base
    {


        [Test, TestCaseSource("AddTestDataConfig")]
        [Parallelizable(ParallelScope.All)]
        public void EndToEndTest(string fname, string lname, string email, string number,string dob, string address, string input,string subject)
        {
            //JavaScript Executor
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver.Value;

            //First Page 
            FirstPage firstPage = new FirstPage(driver.Value, js);
            IWebElement frameScroll = firstPage.viewCards();
            js.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);

            //Practicepage opject after click in firstpage
            PracticeForm practiceForm = firstPage.getFormCard();
             
            //PracticePage 
            practiceForm.getFilledForm(fname,lname, email, number);
            
            //datepicker executed
            handalingDatePicker datePicker = new handalingDatePicker(driver.Value, js);
            datePicker.clicckDate(dob);

            //subject select
            AutoSuggestionDropdown dropdown = new AutoSuggestionDropdown(driver.Value);
            dropdown.selectOption(input,subject);
            driver.Value.FindElement(By.CssSelector("#userForm")).Click();

            practiceForm.reamainingTask(address);
            //practiceForm.StateDropdown("NCR");
            //practiceForm.CityDropdown("Delhi");
            GetDataFromModel getData= new GetDataFromModel(driver.Value);
            //getData.gettingTitle();

            SaveDataToExcel saveDataToExcel= new SaveDataToExcel();
            saveDataToExcel.SaveTableDataToExcel(driver.Value);
        }
        
        
        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {

            //passing data from Json 
            yield return new TestCaseData(getDataParser().extractData("firstName"), getDataParser().extractData("lastName"), getDataParser().extractData("emailAdd"), getDataParser().extractData("PhoneNumber"), getDataParser().extractData("dateOfBirth"), getDataParser().extractData("address"), getDataParser().extractData("inputsub"), getDataParser().extractData("subjectName"));
            //passing wrong email so test will fail
            yield return new TestCaseData(getDataParser().extractData("firstName"), getDataParser().extractData("lastName"), getDataParser().extractData("emailAdd_Wrong"), getDataParser().extractData("PhoneNumber"), getDataParser().extractData("dateOfBirth"), getDataParser().extractData("address"), getDataParser().extractData("inputsub"), getDataParser().extractData("subjectName"));
            //onmy passing 4 parameters so test will fail
            yield return new TestCaseData(getDataParser().extractData("firstName"), getDataParser().extractData("lastName"), getDataParser().extractData("emailAdd"), getDataParser().extractData("PhoneNumber"));

            if (FromExcelData.datacol == null || FromExcelData.datacol.Count == 0)
            {
                FromExcelData.populateInCollection(@"C:\Users\Paras\Documents\Book1.xlsx");
            }
            ////passing data from excel sheet
            yield return new TestCaseData(FromExcelData.Readdata(1, "firstName"), FromExcelData.Readdata(1, "lastName"), FromExcelData.Readdata(1, "emailAdd"), FromExcelData.Readdata(1, "PhoneNumber"), FromExcelData.Readdata(1, "dateOfBirth"), FromExcelData.Readdata(1, "address"), FromExcelData.Readdata(1, "inputsub"), FromExcelData.Readdata(1, "subjectName"));


        }
    }
}