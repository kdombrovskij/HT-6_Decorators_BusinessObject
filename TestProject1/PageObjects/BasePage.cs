using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TestProject1.Configurations;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TestProject1.PageObjects
{
    class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='search']")]
        IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//button[@class='button button_color_green button_size_medium search-form__submit ng-star-inserted']")]
        IWebElement searchButton;


        public void makeSearchByKeyword(string Keyword)
        {
            searchInput.SendKeys(Keyword);
            searchButton.Click();
            Properties.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
    }
}
