using OpenQA.Selenium;

namespace SeleniumTDD.Pages
{
    public class HomePage : BasePage
    {
        #region WebElements
        private IWebElement SearchBar => Driver.FindElement(By.CssSelector("input[aria-label='Search']"));
        private IWebElement SearchIcon => Driver.FindElement(By.CssSelector(".nav-input[value='Go']"));
        private IWebElement SignInBtn => Driver.FindElement(By.CssSelector("a#nav-link-accountList"));
        #endregion

        #region Methods
        public T SearchItem<T>(string itemName) where T : new()
        {
            WaitUntilDisplayed(SearchBar);
            SearchBar.SendKeys(itemName);
            SearchIcon.Click();
            return new T();
        }

        public T SignIn<T>() where T : new()
        {
            WaitUntilDisplayed(SignInBtn);
            SignInBtn.Click();
            return new T();
        }
        #endregion
    }
}
