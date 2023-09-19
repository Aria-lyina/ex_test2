using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ex_test
{
    public class Dict
    {
        string reportFilePath;

        public string report_file { get =>reportFilePath; }
        public Dictionary<string, int> GetCountTag(string address)
        {
            HtmlWeb web = new HtmlWeb();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HtmlDocument doc = web.Load(address);

            Dictionary<string, int> dict_tag = new Dictionary<string, int>();

            foreach (HtmlNode node in doc.DocumentNode.Descendants())
            {
                if (node.NodeType == HtmlNodeType.Element)
                {
                    string tagName = node.Name;

                    if (dict_tag.ContainsKey(tagName))
                    {
                        dict_tag[tagName]++;
                    }
                    else
                    {
                        dict_tag.Add(tagName, 1);
                    }
                }
            }

            reportFilePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "report.txt");
            using (StreamWriter writer = new StreamWriter(reportFilePath))
            {
                foreach (KeyValuePair<string, int> pair in dict_tag)
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }

            Console.WriteLine($"Отчёт успешно сохранён в файл {reportFilePath}");
         //   Console.ReadLine();
            return dict_tag;
        }

        public Dictionary<string, int> GetCountTag()
        {
            Console.Write("Введите адрес HTML-страницы: ");
            string url = Console.ReadLine();

            HtmlWeb web = new HtmlWeb();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HtmlDocument doc = web.Load(url);

            Dictionary<string, int> dict_tag = new Dictionary<string, int>();

            foreach (HtmlNode node in doc.DocumentNode.Descendants())
            {
                if (node.NodeType == HtmlNodeType.Element)
                {
                    string tagName = node.Name;

                    if (dict_tag.ContainsKey(tagName))
                    {
                        dict_tag[tagName]++;
                    }
                    else
                    {
                        dict_tag.Add(tagName, 1);
                    }
                }
            }

            reportFilePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "report.txt");
            using (StreamWriter writer = new StreamWriter(reportFilePath))
            {
                foreach (KeyValuePair<string, int> pair in dict_tag)
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }

            Console.WriteLine($"Отчёт успешно сохранён в файл {reportFilePath}");
            Console.ReadLine();
            return dict_tag;
        }
    }   
}
