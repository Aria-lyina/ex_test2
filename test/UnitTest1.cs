using ex_test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void html()
        {
            Dictionary<string, int> d = new Dict().GetCountTag("https://learn.microsoft.com/ru-ru/dotnet/core/testing/unit-testing-with-mstest");
            if (!d.ContainsKey("html")) Assert.Fail("The test is FAILED! no contains <html> but his exists.");
            else if (d["html"] != 1) Assert.Fail("The test is FAILED! count <html> more 1 but his 1.");
        }

        [TestMethod]
        public void empty()
        {
            Dictionary<string, int> d = new Dict().GetCountTag("C:\\test\\семестр 3\\test\\NERV.txt");
            if (d.Count != 0) Assert.Fail("The test is FAILED! it must not contain tag in file.");
        }

        [TestMethod]
        public void same_results()
        {
            Dictionary<string, int> d1 = new Dict().GetCountTag("https://learn.microsoft.com/ru-ru/dotnet/core/testing/unit-testing-with-mstest");
            //Dictionary<string, int> d1 = new Dict().GetCountTag("C:\\test\\семестр 3\\test\\NERV.txt");
            Dictionary<string, int> d2 = new Dict().GetCountTag("https://learn.microsoft.com/ru-ru/dotnet/core/testing/unit-testing-with-mstest");
            if (Enumerable.SequenceEqual(d1, d2) == false) Assert.Fail("The test is FAILED! dont same results.");
        }

        [TestMethod]
        public void count_img()
        {
            Dictionary<string, int> d = new Dict().GetCountTag("https://stackoverflow.com/questions/47269609/system-net-securityprotocoltype-tls12-definition-not-found");
            //Dictionary<string, int> d1 = new Dict().GetCountTag("C:\\test\\семестр 3\\test\\NERV.txt");
            if (!d.ContainsKey("img")) Assert.Fail("The test is FAILED! no contains <img> but his exists.");
            else if (d["img"] != 15) Assert.Fail("The test is FAILED! count <img> != 15 but his 15.");
        }

        [TestMethod]
        public void dont_same_result()
        {
            Dictionary<string, int> d1 = new Dict().GetCountTag("C:\\test\\семестр 3\\test\\NERV.txt");
            Dictionary<string, int> d2 = new Dict().GetCountTag("https://learn.microsoft.com/ru-ru/dotnet/core/testing/unit-testing-with-mstest");
            if (Enumerable.SequenceEqual(d1, d2) == true) Assert.Fail("The test is FAILED! same results.");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Net.WebException), "Exception test!!!")]
        public void test_href()
        {
            Dictionary<string, int> d1 = new Dict().GetCountTag("https://sckoverfl.com/questions/47209/systenet-securityprocoltype-tl2-defnitio");
        }

        [TestMethod]
        public void write_report()
        {
            Dict dict = new Dict();
            Dictionary<string, int> d1 = dict.GetCountTag("https://stackoverflow.com/questions/47269609/system-net-securityprotocoltype-tls12-definitio");
            FileInfo file = new FileInfo(dict.report_file);
            if (file.Exists == false) Assert.Fail("No create file!");
            else if (file.Length == 0) Assert.Fail("File empty!");
        }

        [TestMethod]
        public void comparison_write_read()
        {
            Dict dict1 = new Dict();
            Dictionary<string, int> d1 = dict1.GetCountTag("https://stackoverflow.com/questions/47269609/system-net-securityprotocoltype-tls12-definitio");

            string textFromFile;

            using (FileStream fstream = File.OpenRead(dict1.report_file))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                textFromFile = Encoding.Default.GetString(buffer);
            }
            //" ", "\n","-","\t","\r"

            string[] text = textFromFile.Split(new string[] { }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < text.Length; i++)
            {
                if (d1.ContainsKey(text[i])==false) Assert.Fail("No correct write or read!");
                if (d1[text[i]] != Int32.Parse(text[++i])) Assert.Fail("No correct write or read!");
            }
        }
    }
}
