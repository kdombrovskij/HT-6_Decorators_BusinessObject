using System;
using System.Threading;
using HT6_Decorators_BusinessObject.Decorators;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HT6_Decorators_BusinessObject.PageObjects
{
    class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='search']")]
        IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//button[@class='button button_color_green button_size_medium search-form__submit ng-star-inserted']")]
        IWebElement searchButton;


        public void makeSearchByKeyword(string Keyword)
        {
            searchInput.EnterText(Keyword, "search input");
            searchButton.ClickOnElement("search button");
            Thread.Sleep(3000);
        }
    }
}
