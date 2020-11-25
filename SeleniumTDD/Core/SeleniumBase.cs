using OpenQA.Selenium.Interactions;
using SeleniumTDD.Core.Operation;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Linq;
using System;

namespace SeleniumTDD.Core
{
    public abstract class SeleniumBase : IWebOperation<By, IWebElement>, ISelectOperation<By>, IWindowOperation, IFrameOperation<By>
    {

        private IWebDriver driver = (IWebDriver)ExecutorFactory.GetToolFactory().GetInstance<IWebDriver>();

        int _drivertimeOut = 60;
        int _pollingInterval = 500;
        public IWebDriver GetDriver()
        {
            return this.driver;
        }

        //@Override
        public IWebElement WaitForElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_drivertimeOut));
            if (_pollingInterval > 0)
                wait.PollingInterval = TimeSpan.FromSeconds(_pollingInterval);
            IWebElement element = wait.Until(d => driver.FindElement(by));
            return element;
        }
        public List<IWebElement> WaitForElements(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_drivertimeOut));
            if (_pollingInterval > 0)
                wait.PollingInterval = TimeSpan.FromSeconds(_pollingInterval);
            IReadOnlyCollection<IWebElement> elements = wait.Until(d => driver.FindElements(by));
            return elements.ToList<IWebElement>();
        }

        private IWebElement IsElementDisplayed(By by)
        {
            IWebElement element = WaitForElement(by);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_drivertimeOut));
            wait.Until(e => element.Displayed);
            return element;
        }
        private IWebElement IsElementEnabled(By by)
        {
            IWebElement element = IsElementDisplayed(by);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_drivertimeOut));
            wait.Until(e => element.Enabled);
            return element;
        }

        private IWebElement IsElementClickable(By by)
        {
            return IsElementEnabled(by);
        }

        // @Override
        public void MoveToElement(By by)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(IsElementDisplayed(by)).Build().Perform();
        }

        //Override
        public void ClickButton(By by)
        {
            IsElementClickable(by).Click();
        }

        //@Override
        public bool HasElement(By by)
        {
            return WaitForElements(by).Count() >= 0;
        }

        // @Override
        public bool HasNoElementAsExpected(By by)
        {
            try
            {
                WaitForElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // @Override
        public void WaitForElementGone(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_drivertimeOut));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            wait.Until((driver => WaitForElements(by).Count == 0));
        }


        public bool VerifyElementSelected(By by, bool selected)
        {
            IWebElement element = IsElementDisplayed(by);
            return element.Selected == selected;
        }


        public void ScrollToElementAndClick(By by)
        {
            ScrollToElement(by);
            IsElementClickable(by).Click();
        }

        // @Override
        public void ScrollToElement(By by)
        {
            int scrollBy = IsElementEnabled(by).Location.Y + 25;
            GetJavaScriptExecutor().ExecuteScript("window.scrollBy(0," + scrollBy + ");");
        }

        // @Override
        public string GetTextFromElement(By by)
        {
            return WaitForElement(by).Text;
        }

        //@Override
        public void SelectRadioButtonByValue(By radioGroup, String valueToSelect)
        {
            // Find the radio group element
            List<IWebElement> radioLabels = driver.FindElements(radioGroup).ToList<IWebElement>();
            for (int i = 0; i < radioLabels.Count(); i++)
            {
                if (radioLabels[i].Text.Trim().Equals(valueToSelect.Trim(), StringComparison.InvariantCultureIgnoreCase))
                {
                    radioLabels[i].Click();
                    break;
                }
            }
        }

        // @Override
        public int CountElements(By by, long currentWaitMillis)
        {
            int result = 0;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_drivertimeOut));
            if (currentWaitMillis > 0)
            {
                wait.Timeout = TimeSpan.FromMilliseconds(currentWaitMillis);
            }
            if (_pollingInterval > 0)
                wait.PollingInterval = TimeSpan.FromSeconds(_pollingInterval);
            IReadOnlyCollection<IWebElement> elements = wait.Until(d => driver.FindElements(by));
            wait.Until(e => elements.Count > 0);
            result = driver.FindElements(by).Count();

            return result;
        }

        public SelectElement GetDropDownelement(IWebElement element)
        {
            return new SelectElement(element);
        }

        // @Override
        public void SendValuesToWebElement(By by, string value)
        {
            WaitForElement(by).SendKeys(value);
        }

        // @Override
        public bool IsDisabled(By by)
        {
            return WaitForElement(by).Displayed;
            //return WaitForElement(by).GetAttribute("disabled").Equals("disabled", StringComparison.InvariantCultureIgnoreCase);
        }

        // @Override
        public bool IsEnabled(By by)
        {
            //   return WaitForElement(by).GetAttribute("enabled").equalsIgnoreCase("enabled");
            IWebElement element = WaitForElement(by);
            return element.Enabled;

        }

        public IJavaScriptExecutor GetJavaScriptExecutor()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return js;
        }

        // @Override
        public void SelectItemByValue(By by, String itemToSelect)
        {
            IWebElement element = WaitForElement(by);
            GetDropDownelement(element).SelectByValue(itemToSelect);
        }

        // @Override
        public void SelectItemByText(By by, String text)
        {
            IWebElement element = WaitForElement(by);
            GetDropDownelement(element).SelectByText(text);
        }

        //@Override
        public void SelectItemByIndex(By by, int index)
        {
            IWebElement element = WaitForElement(by);
            GetDropDownelement(element).SelectByIndex(index);
        }

        // @Override
        public void SwitchToLastTab()
        {
            List<string> browserTabs = driver.WindowHandles.ToList<string>();
            driver.SwitchTo().Window(browserTabs[browserTabs.Count() - 1]);
        }

        // @Override
        public void SwitchToFirstTab()
        {
            List<string> handles = driver.WindowHandles.ToList<string>();
            for (int i = handles.Count(); i > 1; i--)
            {
                driver.SwitchTo().Window(handles[i - 1]);
                driver.Close();
            }
            driver.SwitchTo().Window(handles[0]);
        }
        // @Override
        public void CloseTab()
        {
            driver.Close();
            List<string> browserTabs = driver.WindowHandles.ToList<string>();
            driver.SwitchTo().Window(browserTabs[browserTabs.Count - 1]);
        }

        // @Override
        public void WaitTillMultipleTabOpens()
        {
            IReadOnlyCollection<string> allWindows = driver.WindowHandles;
            while (allWindows.Count() == 1)
            {
                allWindows = driver.WindowHandles;
            }
        }

        // @Override
        public void SwitchToFrame(By identifier)
        {
            driver.SwitchTo().Frame(WaitForElement(identifier));
        }

        // @Override
        public void SwitchToFrameContainingText(string identifier)
        {
            driver.SwitchTo().Frame(identifier);
        }

        //@Override
        public void SwitchToFrameByIndex(int index)
        {
            driver.SwitchTo().Frame(index);
        }

        public void HandledSleep(int sleepInSeconds)
        {
            throw new NotImplementedException();
        }
    }
}
