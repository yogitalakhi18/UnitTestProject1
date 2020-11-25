using System.Collections.Generic;
using OpenQA.Selenium;
using System.Linq;

namespace SeleniumTDD.Pages
{
    public class CartPage : BasePage
    {
        private List<IWebElement> Items => Driver.FindElements(By.CssSelector(".a-list-item .sc-product-title.a-text-bold")).ToList();

        public string GetProductNameInCart()
        {
            return Items[0].Text;
        }
    }
}
