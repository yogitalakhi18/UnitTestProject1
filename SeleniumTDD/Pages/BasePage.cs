using OpenQA.Selenium.Support.UI;
using SeleniumTDD.Core;
using OpenQA.Selenium;
using System;

namespace SeleniumTDD.Pages
{
    public class BasePage : SeleniumBase
    {
        public static IWebDriver Driver;
        public static WebDriverWait webDriverWait;
        public BasePage()
        {
            Driver = GetDriver();
            webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
        }

        public bool WaitUntilDisplayed(By by)
        {
            return webDriverWait.Until(x => x.FindElement(by).Displayed);
        }

        public bool WaitUntilDisplayed(IWebElement element)
        {
            return webDriverWait.Until(x => element.Displayed);
        }

        public bool WaitForElementDisplayedUntil(IWebElement element, int timeout)
        {
            webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            return webDriverWait.Until(x => element.Displayed);
        }
    }
}
