using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using HT6_Decorators_BusinessObject.Decorators;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace HT6_Decorators_BusinessObject.PageObjects
{
    class SearchResultPage : BasePage
    {
        public SearchResultPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@data-filter-name='producer']//input")]
        IWebElement producerSearch;

        [FindsBy(How = How.XPath, Using = "//div[@data-filter-name='producer']//a[1]")]
        IWebElement producerCheckbox;

        [FindsBy(How = How.CssSelector, Using = "select[class*='select']")]
        IWebElement elementSort;

        SelectElement DropdownElement
        {
            get { return new SelectElement(elementSort); }
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='goods-tile__price price--red ng-star-inserted']//button")]
        IWebElement buyButton;


        public void filterByProducer(string filter)
        {
            Thread.Sleep(3000);
            producerSearch.EnterText(filter, "producer search");
            Thread.Sleep(3000);
            producerCheckbox.ClickOnElement("producer checkbox");
        }

        public void changeSortingOrder(int order)
        {
            DropdownElement.SelectByIndex(order);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void clickBuyButton()
        {
            Thread.Sleep(3000);
            buyButton.ClickOnElement("buy button");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
    }
}
