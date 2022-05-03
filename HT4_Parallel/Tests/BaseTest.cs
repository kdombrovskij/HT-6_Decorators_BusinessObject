using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;

namespace HT4_Parallel.Tests
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class BaseTest
    {
        private IWebDriver _driver;
        public IWebDriver Driver { get { return _driver; } }

        [SetUp]
        public void Setup()
        {
            Log.Logger = new LoggerConfiguration()
               .WriteTo.File(@"D:\HT\HT 4\HT4_Parallel\Logs\Logs.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();
            Log.Information("Log started");
            _driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://rozetka.com.ua/");
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Quit();
            Log.Information("Log closed");
        }
    }
}