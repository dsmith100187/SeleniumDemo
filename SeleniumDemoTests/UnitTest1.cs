using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumDemoFramework;

namespace SeleniumDemoTests
{
    [TestClass]
    public class UnitTest1
    {
        string google = "http://www.google.com";
        string ivanti = "http://www.ivanti.com";

        [TestMethod]
        public void Open_Browser_To_Google()
        {
            string url = google;
            string title = "Google";
            Browser.Open(url);
            Assert.IsTrue(Browser.IsAt(title));
        }

        [TestMethod]
        public void Type_In_Seach_Bar()
        {
            string url = google;
            string query = "Ivanti";
            string title = $"{query} - Google Search";
            Browser.Open(url);
            Browser.Search(query);
            Assert.IsTrue(Browser.IsAt(title));
        }

        [TestMethod]
        public void Go_To_Ivanti_Website()
        {
            string url = google;
            string query = "Ivanti";
            string title = $"{query} - Google Search";
            Browser.Open(url);
            Browser.SearchAndGo(query);
        }

        [TestMethod]
        public void Ivanti_Webinars()
        {
            string url = ivanti;
            string title = "January Patch Tuesday 2017";
            Browser.Open(url);
            Assert.IsTrue(Browser.GoToWebinars() == title);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Browser.Close();
        }
    }
}
