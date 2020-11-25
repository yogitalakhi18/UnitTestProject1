using System.Collections.Generic;
using OpenQA.Selenium;
using System.Linq;

namespace SeleniumTDD.Pages
{
    public class SearchResultsPage : HomePage
    {
        private IReadOnlyCollection<IWebElement> SearchResults => Driver.FindElements(By.CssSelector("div.a-section span.a-size-medium"));
        private List<IWebElement> ListResults => SearchResults.ToList();
        
        public T SelectProduct<T>(string keyword) where T : new()
        {
            WaitUntilDisplayed(ListResults[0]);
            IWebElement elementToClick = ListResults.FirstOrDefault(x => x.Text.Contains(keyword));
            WaitForElementDisplayedUntil(elementToClick, 90);
            elementToClick.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            return new T();
        }
    }
}

