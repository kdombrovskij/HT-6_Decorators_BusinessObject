using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace HT4_Parallel.PageObjects
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

        [FindsBy(How = How.XPath, Using = "//div[@data-filter-name='producer']//button[@class='sidebar-search__clear ng-star-inserted']")]
        IWebElement clearSearchButton;

        [FindsBy(How = How.CssSelector, Using = "select[class*='select']")]
        IWebElement elementSort;

        [FindsBy(How = How.XPath, Using = "//div[@class='cart-receipt__sum-price']/span[1]")]
        IWebElement cartTotal;
        SelectElement DropdownElement
        {
            get { return new SelectElement(elementSort); }
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='goods-tile__price price--red ng-star-inserted']//button")]
        IWebElement buyButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='header__button ng-star-inserted header__button--active']")]
        IWebElement shoppingCartButton;

        public void filterByProducer(string filter)
        {
            Thread.Sleep(3000);
            producerSearch.SendKeys(filter);
            Thread.Sleep(3000);
            producerCheckbox.Click();
        }

        public void changeSortingOrder(int order)
        {
            DropdownElement.SelectByIndex(order);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void clickBuyButton()
        {
            Thread.Sleep(3000);
            buyButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public int getShoppingCartSumm()
        {
            shoppingCartButton.Click();
            return int.Parse(cartTotal.Text);
        }
    }
}
