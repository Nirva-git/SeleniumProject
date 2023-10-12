using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumNunitTestProject.Utilities
{
    public class SaveDataToExcel
    {
       
        public void SaveTableDataToExcel(IWebDriver driver)

        {
            // Set the EPPlus LicenseContext to NonCommercial or Commercial using static
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Get the table data using the gettingData method
            GetDataFromModel getData= new GetDataFromModel(driver);
                List<List<string>> tableData =  getData.gettingData();

                // Create a new Excel package
                using (var package = new ExcelPackage())
                {
                    // Add a new worksheet to the Excel package
                    var worksheet = package.Workbook.Worksheets.Add("TableData");

                    // Loop through the table data and write it to the worksheet
                    for (int row = 0; row < tableData.Count; row++)
                    {
                        for (int col = 0; col < tableData[row].Count; col++)
                        {
                            // Write data to the Excel worksheet
                            worksheet.Cells[row + 1, col + 1].Value = tableData[row][col];
                        }
                    }

                // Save the Excel file
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var filePath = @"C:\Users\Paras\source\repos\Selenium Projects\SeleniumTestProject\"; // Your file path
                var fileName = $"TableData_{timestamp}.xlsx";
                var excelFile = new FileInfo(Path.Combine(filePath, fileName));
                package.SaveAs(excelFile);
                }
            }
    }
}
