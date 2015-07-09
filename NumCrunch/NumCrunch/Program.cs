using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace NumCrunch
{
    static class Program
    {
        static void Main(string[] args)
        {
            double[] sourceData = FileOps.ReadFile("src.txt");
            double[] resultData = new double[sourceData.Length];
            ScalarKalman scalarKalman = new ScalarKalman()
            {
                Value = 0.01,
                EstimationErrorCovar = 1,
                MeasureNoiseCovar = 50,
                ProcessNoiseCovar = 0.5
            };
            for (int i = 0; i < sourceData.Length; i++)
            {
                scalarKalman.Update(sourceData[i]);
                resultData[i] = scalarKalman.Value;
            }
            FileOps.WriteFile("res.txt", resultData);

            //Application excel = new Application();
            //Workbook workbook = excel.Workbooks.Add();
            //Worksheet worksheet = (Worksheet)excel.Worksheets.Item[1];
            
            ////Include plotting operations here
            //for (int i = 0; i < sourceData.Length; i++)
            //{
            //    worksheet.Cells[1, i] = sourceData[i];
            //}


            //workbook.SaveAs(Path.Combine(Environment.CurrentDirectory, "Plot.xlsx"));
            //FileOps.ReleaseObject(worksheet);
            //FileOps.ReleaseObject(workbook);
            //FileOps.ReleaseObject(excel);
            //Process.Start(Path.Combine(Environment.CurrentDirectory, "Plot.xlsx"));
        }
    }
}
