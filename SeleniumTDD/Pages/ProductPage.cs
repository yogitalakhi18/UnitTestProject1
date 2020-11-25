using OpenQA.Selenium;

namespace SeleniumTDD.Pages
{
    public class ProductPage : BasePage
    {
        #region WebElements
        private IWebElement AddToCartBtn => Driver.FindElement(By.Id("add-to-cart-button"));
        private IWebElement CartBtn => Driver.FindElement(By.CssSelector("input[aria-labelledby*='view-cart-button']"));
        private IWebElement Product => Driver.FindElement(By.CssSelector("span#productTitle"));
        #endregion

        #region Methods
        public T AddToCart<T>() where T :  new()
        {
            WaitUntilDisplayed(AddToCartBtn);
            AddToCartBtn.Click();
            return new T();
        }

        public T GoToCart<T>() where T : new()
        {
            WaitForElementDisplayedUntil(CartBtn, 180);
            CartBtn.Click();
            return new T();
        }

        public string GetProductName()
        {
            WaitUntilDisplayed(Product);
            return Product.Text;
        }
        #endregion
    }
}

