using System.IO;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Data.Common;

namespace SeleniumNunitTestProject.Utilities
{
    public class FromExcelData
    {
        private static DataTable ExcelToDataTable(string fileName)
        {
            // Register encoding provider if necessary
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            DataTable dataTable; 

            // Replace with your Excel file path
            string filePath = fileName;

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Create an ExcelDataReader
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // Set this to true to use the first row as a header
                        }
                    });

                    // Access the first DataTable in the result
                    dataTable = result.Tables[0];

                    // Now, the first row is set as the header in the 'dataTable'
                }
            }
            return dataTable;

        }

        public static List<DataCollection> datacol = new List<DataCollection>();

        public static void populateInCollection(string fileName)
        {

            DataTable table = ExcelToDataTable(fileName);
            // Log the number of rows and columns retrieved
            Console.WriteLine($"Rows: {table.Rows.Count}, Columns: {table.Columns.Count}");

            //Iterate to the rows and cols of the table
            for (int col = 0; col < table.Columns.Count; col++)
            {
                for(int row = 1; row < table.Rows.Count; row++)
                {
                    DataCollection dtable = new DataCollection()
                    {
                        rowNumber = row,
                        colName =  table.Columns[col].ColumnName,
                        colvalue = table.Rows[row][col].ToString()
                    };
                    //add all the details for the each row
                    datacol.Add(dtable);
                }
            }

        }

        public static string Readdata(int rowNumber, string ColName)
        {
            try
            {
                // retriving data using LINQ to reduce much of iterations

                string data = (from colData in datacol
                               where colData.colName.Equals(ColName, StringComparison.OrdinalIgnoreCase) && colData.rowNumber == rowNumber
                               select colData.colvalue).FirstOrDefault();
                return data.ToString();
            }
            catch
            {
                return null;
            }
        }

    }           
        public class DataCollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colvalue { get; set; }
        }
    
}
