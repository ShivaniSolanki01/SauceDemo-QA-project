
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo.Tests.Base;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests.Tests
{
    public class NavigationTests : BaseTest
    {
        private LoginPage login = null!;
        private ProductsPage products = null!;

        [SetUp]
        public void SetUpNavigation()
        {
            login = new LoginPage(Driver);
            products = new ProductsPage(Driver);

            login.Open();
            login.Login("standard_user", "secret_sauce");

            WaitForVisible(By.ClassName("inventory_list"));
        }

        [Test]
        public void TC022_LogoutReturnsToLoginPage()
        {
            products.Logout();

            Wait.Until(driver =>
                driver.FindElements(By.Id("login-button")).Count > 0
            );

            Assert.That(Driver.Url, Does.Contain("saucedemo.com"));
            Assert.That(login.IsLoginButtonDisplayed(), Is.True);
        }

        [Test]
        public void TC023_LogoutClearsLoginSession()
        {
            products.Logout();

            Wait.Until(driver =>
                driver.FindElements(By.Id("login-button")).Count > 0
            );

            Assert.That(
                Driver.FindElements(By.Id("login-button")).Count,
                Is.EqualTo(1)
            );
        }

        [Test]
        public void TC024_CartNavigationOpensCartPage()
        {
            products.AddBackpackToCart();
            products.OpenCart();

            Wait.Until(driver =>
                driver.Url.Contains("cart.html")
            );

            Wait.Until(driver =>
                driver.FindElement(By.ClassName("title")).Text == "Your Cart"
            );

            Assert.That(Driver.Url, Does.Contain("cart.html"));

            Assert.That(
                Driver.FindElement(By.ClassName("title")).Text,
                Is.EqualTo("Your Cart")
            );
        }
    }
}
