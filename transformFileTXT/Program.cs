using System;
using System.IO;
using System.Threading;
using System.Globalization;


namespace transformFileTXT
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcepath = @"C:\Users\Emanuel\OneDrive - Universidade Federal do Rio Grande do Sul\Cources and others\C#\Text\File1.txt";
            string targetpath = @"C:\Users\Emanuel\OneDrive - Universidade Federal do Rio Grande do Sul\Cources and others\C#\Text\File2.txt";

            try
            {
                string[] lines = File.ReadAllLines(sourcepath);
                StreamWriter strm = File.CreateText(targetpath);
                strm.Flush();
                strm.Close();

                foreach (string line in lines)
                {
                    string[] filds = line.Split(',');
                    string name = filds[0];
                    double price = double.Parse(filds[1], CultureInfo.InvariantCulture);
                    int units = int.Parse(filds[2]);
                    using (StreamWriter sw = File.AppendText(targetpath))
                    {
                        sw.WriteLine(name + "," + (price*units).ToString("F2", CultureInfo.InvariantCulture));
                    }                    
                }
                Console.WriteLine("Finished writing!");
            }

            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }


        }

    }
}
