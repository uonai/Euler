using HtmlAgilityPack;
using System;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = 1;

            for (var i = 0; i < 5; i++)
            {
                number++;
                var url = $"https://projecteuler.net/problem={number}";
                var web = new HtmlWeb();
                var doc = web.Load(url);
                string title = doc.DocumentNode.SelectSingleNode("//h2").InnerText;
                Console.WriteLine("PROBLEM TITLE:");
                Console.WriteLine(title);
                Console.WriteLine("PROBLEM CONTENT:");
                var problemLines = doc.DocumentNode.SelectNodes("//div[contains(@class, 'problem_content')]/p");
                foreach (HtmlNode problemLine in problemLines)
                {
                    Console.WriteLine(problemLine.InnerHtml);
                }
            }
            Console.ReadLine();
        }
    }
}
