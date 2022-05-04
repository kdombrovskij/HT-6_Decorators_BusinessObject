using NUnit.Framework;
using HT6_Decorators_BusinessObject.PageObjects;
using HT6_Decorators_BusinessObject.Utils;
using HT6_Decorators_BusinessObject.DataSource;
using HT6_Decorators_BusinessObject.BusinessObject;
using OpenQA.Selenium.DevTools;
using Serilog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[assembly: LevelOfParallelism(3)]

namespace HT6_Decorators_BusinessObject.Tests
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]


    class CardSummCheckTest
    {
        private IWebDriver _driver;
        public IWebDriver Driver { get { return _driver; } }

        [SetUp]
        public void Setup()
        {
            Serilog.Log.Logger = new LoggerConfiguration()
               .WriteTo.File(@"D:\HT\HT-4_Parallel\HT6_Decorators_BusinessObject\Logs\Logs.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();
            Serilog.Log.Information("Log started");
            _driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://rozetka.com.ua/");
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Quit();
            Serilog.Log.Information("Log closed");
        }

        [Parallelizable(scope: ParallelScope.All)]
        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.TestData))]
        public void Test1(Filter filter)
        {
            MakeSearch makeSearch = new();
            makeSearch.makeSearchByKeyword(Driver, filter.item);
            MakeOrder makeOrder = new();
            makeOrder.selectProducerAndFilters(Driver, filter.producer, filter.sort);
            makeOrder.buyProduct(Driver);
            CheckSumm checkSumm = new();
            int total = checkSumm.checkSumm(Driver);
            Assert.That(total, Is.LessThan(filter.price));
        }

    }
}
