using NUnit.Framework;
using TestProject1.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TestProject1.PageObjects;
using System.Linq;
using System.Xml.Linq;
using System.Collections;

namespace TestProject1
{
    public class Tests
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [SetUp]
        public void Setup()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://rozetka.com.ua/");
            Properties.driver.Manage().Window.Maximize();
            Properties.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static IEnumerable testDataXml => GetTestDataXml();
        private static IEnumerable GetTestDataXml()
        {
            var doc = XDocument.Load(@"D:\HT\HT 3\HT 3\TestProject1\TestData\TestData.xml");
            return
            from testdata in doc.Descendants("testdata")
            let product = testdata.Attribute("product").Value
            let filter = testdata.Attribute("filter").Value
            let summ = testdata.Attribute("summ").Value
            select new object[] { product, filter, summ };
        }


        [Test]
        [TestCaseSource("testDataXml")]
        public void Test1(string product, string filter, string summ)
        {
            BasePage homePage = new BasePage();
            log.Info("Rozetka page opened successfully");
            homePage.makeSearchByKeyword(product);
            SearchResultPage searchResultPage = new SearchResultPage();
            searchResultPage.filterByProducer(filter);
            searchResultPage.changeSortingOrder(2);
            searchResultPage.clickBuyButton();
            int total = searchResultPage.getShoppingCartSumm();
            Assert.That(total, Is.LessThan(Int32.Parse(summ)));
        }

        [TearDown]
        public void CleanUp()
        {
            Properties.driver.Close();
        }
    }
}