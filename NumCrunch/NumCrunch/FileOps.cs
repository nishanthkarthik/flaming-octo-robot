using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumCrunch
{
    class FileOps
    {
        public static double[] ReadFile(string fileName)
        {
            IEnumerable<string> stringEnumerable = File.ReadAllLines(fileName);
            double[] doubleArray = new double[stringEnumerable.Count()];
            for (int i = 0; i < stringEnumerable.Count(); i++)
            {
                doubleArray[i] = double.Parse(stringEnumerable.ElementAt(i));
            }
            return doubleArray;
        }

        public static void WriteFile(string fileName, double[] data)
        {
            using (StreamWriter writer = File.CreateText(fileName))
            {
                foreach (double t in data)
                {
                    writer.WriteLine(t);
                }
            }
        }

        public static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Exception Occured while releasing object - " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
