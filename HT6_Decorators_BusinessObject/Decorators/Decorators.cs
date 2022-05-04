using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HT6_Decorators_BusinessObject.Decorators
{
    public static class Decorators
    {
        public static void ClickOnElement(this IWebElement element, string elementName)
        {
            element.Click();
            Console.WriteLine("Clicked on {0}.", elementName);
        }

        public static void EnterText(this IWebElement element, string text, string elementName)
        {

            element.Clear();
            element.SendKeys(text);
            Console.WriteLine("{0} entered in the {1} field.", text, elementName);
        }

    }
}
