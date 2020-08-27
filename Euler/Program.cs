using System;


namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Beginning scrape of Project Euler");

            var problemList = FileProcessor.FormatObject();
            FileProcessor.WriteFile(problemList);

            Console.ReadLine();
        }
    }
}
