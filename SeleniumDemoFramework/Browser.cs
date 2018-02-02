using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace SeleniumDemoFramework
{
    public static class Browser
    {
        static IWebDriver driver;

        public static void Open(string url)
        {
            driver = new ChromeDriver();
            driver.Url = url;
        }

        public static bool IsAt(string title)
        {
            return driver.Title == title;
        }

        public static void Close()
        {
            driver.Close();
        }

        public static void Search(string query)
        {
            driver.FindElement(By.Id("lst-ib")).SendKeys(query);
            driver.FindElement(By.Name("btnK")).Click();
        }

        public static void SearchAndGo(string query)
        {
            driver.FindElement(By.Id("lst-ib")).SendKeys(query);
            driver.FindElement(By.Name("btnK")).Click();
            driver.FindElement(By.LinkText("Ivanti: IT Management Software Solutions")).Click();
        }

        public static string GoToWebinars()
        {
            var webinarPageLink = driver.FindElement(By.XPath("//*[@id=\"mainFooter\"]/div/div/div[1]/nav/div[1]/div[1]/a"));
            webinarPageLink.Click();

            var selectrics = driver.FindElements(By.ClassName("selectric"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            foreach (var selectric in selectrics)
            {
                var menu = selectric.FindElement(By.ClassName("label")).Text;
                var scrolls = driver.FindElements(By.ClassName("selectric-scroll"));
                

                if (menu == "Product Category")
                {
                    selectric.Click();
                    var elements = scrolls[0].FindElements(By.TagName("li"));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#recorded-webinars > div.recorded-webinar-panel > div.filter-system.row.flex-container > div:nth-child(1) > div > div > div.selectric-items > div")));
                    elements[5].Click();
                }
                else if (menu == "Year")
                {
                    selectric.Click();
                    var elements = scrolls[1].FindElements(By.TagName("li"));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#recorded-webinars > div.recorded-webinar-panel > div.filter-system.row.flex-container > div:nth-child(2) > div > div > div.selectric-items > div")));
                    elements[2].Click();
                }
                else if (menu == "Month")
                {
                    selectric.Click();
                    var elements = scrolls[2].FindElements(By.TagName("li"));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#recorded-webinars > div.recorded-webinar-panel > div.filter-system.row.flex-container > div:nth-child(3) > div > div > div.selectric-items > div")));
                    elements[1].Click();
                }
            }

            var webinarList = driver.FindElement(By.ClassName("recorded-webinar-list"));
            var webinars = webinarList.FindElements(By.ClassName("item"));
            var webinar = webinars[0];

            return webinar.FindElement(By.ClassName("title")).Text;
        }
    }
}
