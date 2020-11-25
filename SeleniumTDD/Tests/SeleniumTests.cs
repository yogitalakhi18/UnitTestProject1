using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumTDD.Core;
using SeleniumTDD.Pages;
using SeleniumTDD.Tests;

namespace SeleniumTDD
{
    [TestClass]
    public class SeleniumTests : BaseTest
    {
        [TestMethod]
        public void VerifyUserIsAbleToAddProductInCart()
        {
            //Starting report
            report.StartTest("Amazon Test Case", "Selenium Test - VerifySearchWithValidInput");
            report.LogInfo("Test Begins...");

            //Fetch text of mobile to add in cart
            string productNameToAdd = new HomePage().SignIn<LoginPage>()
                                                 .Login<HomePage>(RunSettingsHelper.UserId, RunSettingsHelper.Password)
                                                 .SearchItem<SearchResultsPage>(RunSettingsHelper.ItemName)
                                                 .SelectProduct<ProductPage>(RunSettingsHelper.Keyword)
                                                 .GetProductName();

            //Fetch text of mobile added in cart
            string productNameInCart = new ProductPage().AddToCart<ProductPage>()
                                                 .GoToCart<CartPage>()
                                                 .GetProductNameInCart();

            //Verify product is successfully added to cart
            Assert.AreEqual(productNameToAdd, productNameInCart, "User has successfully added the item in cart.");
        }
    }
}
