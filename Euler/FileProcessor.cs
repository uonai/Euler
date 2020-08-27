using Euler.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Euler
{
    public class FileProcessor
    {
        public static object FormatObject()
        {
            var number = 1;

            List<Problem> problemList = new List<Problem>();

            // There are 713 problems on project Euler. This loops through every problem and creates a JSON file wi
            for (var i = 0; i < 714; i++)
            {
                number++;
                var url = $"https://projecteuler.net/problem={number}";
                var web = new HtmlWeb();
                var doc = web.Load(url);

                string title = doc.DocumentNode.SelectSingleNode("//h2").InnerText;

                var problemLines = doc.DocumentNode.SelectNodes("//div[contains(@class, 'problem_content')]/p");
                var problemLinesFormatted = new Stack();
                if (problemLines is object)
                {
                    foreach (HtmlNode problemLine in problemLines)
                    {
                        problemLinesFormatted.Push(problemLine.InnerHtml);
                    }

                    problemList.Add(new Problem
                    {
                        title = title,
                        content = problemLinesFormatted
                    });
                    Console.WriteLine("Problem added: " + number);
                }


            }

            return problemList;
        }

        public static void WriteFile(object problemList)
        {
            string json = JsonConvert.SerializeObject(problemList);

            // Note: this writes to the /bin/Debug folder of the Project.
            string path = Directory.GetCurrentDirectory();

            File.WriteAllText(@path + "ProblemExport.json", json);
        }
    }
}
