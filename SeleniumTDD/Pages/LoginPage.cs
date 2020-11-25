using OpenQA.Selenium;

namespace SeleniumTDD.Pages
{
    public class LoginPage : BasePage
    {
        #region WebElements
        private IWebElement TxtEmail => Driver.FindElement(By.CssSelector("input[name='email']"));
        private IWebElement ContinueBtn => Driver.FindElement(By.CssSelector("input#continue"));
        private IWebElement TxtPassword => Driver.FindElement(By.CssSelector("input[name='password']"));
        private IWebElement LoginBtn => Driver.FindElement(By.CssSelector("span#auth-signin-button"));
        #endregion

        public T Login<T>(string loginId, string loginPassword) where T : new()
        {
            TxtEmail.SendKeys(loginId);
            ContinueBtn.Click();
            WaitUntilDisplayed(TxtPassword);
            TxtPassword.SendKeys(loginPassword);
            LoginBtn.Click();
            return new T();
        }
    }
}
