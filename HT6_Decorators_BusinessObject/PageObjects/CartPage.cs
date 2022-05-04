using OpenQA.Selenium;
using HT6_Decorators_BusinessObject.Decorators;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6_Decorators_BusinessObject.PageObjects
{
    class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@class='header__button ng-star-inserted header__button--active']")]
        IWebElement shoppingCartButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='cart-receipt__sum-price']/span[1]")]
        IWebElement cartTotal;

        public void openCart()
        {
            shoppingCartButton.ClickOnElement("cart button");
            
        }

        public int getTotal()
        {
            return int.Parse(cartTotal.Text);
        }
    }
}
