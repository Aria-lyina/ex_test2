using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using HtmlAgilityPack;

namespace ex_test
{
    class Program
    {
        static void Main()
        {
            Dict d = new Dict();
           d.GetCountTag("https://stackoverflow.com/questions/47269609/system-net-securityprotocoltype-tls12-definition-not-found");
            //d.GetCountTag("https://learn.microsoft.com/ru-ru/dotnet/core/testing/unit-testing-with-mstest");
            //d.GetCountTag("C:\\test\\семестр 3\\test\\NERV.txt");
            Console.ReadLine();
        }
    }
}
