
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo.Tests.Base;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests.Tests
{
    public class CheckoutTests : BaseTest
    {
        private LoginPage login = null!;
        private ProductsPage products = null!;
        private CartPage cart = null!;
        private CheckoutPage checkout = null!;

        [SetUp]
        public void SetUpCheckout()
        {
            login = new LoginPage(Driver);
            products = new ProductsPage(Driver);
            cart = new CartPage(Driver);
            checkout = new CheckoutPage(Driver);

            login.Open();
            login.Login("standard_user", "secret_sauce");

            WaitForVisible(By.ClassName("inventory_list"));

            Assert.That(
                Driver.Url,
                Does.Contain("inventory.html"),
                "Login did not reach the products page."
            );

            products.AddBackpackToCart();
            products.OpenCart();

            WaitForVisible(By.ClassName("cart_item"));

            Assert.That(
                Driver.Url,
                Does.Contain("cart.html"),
                "Opening the cart did not reach the cart page."
            );

            cart.Checkout();

            Wait.Until(driver =>
                driver.Url.Contains("checkout-step-one.html")
            );

            WaitForVisible(By.Id("first-name"));

            Assert.That(
                Driver.Url,
                Does.Contain("checkout-step-one.html"),
                "Checkout did not reach the information page."
            );
        }

        [Test]
        public void TC015_CheckoutInformationPageDisplayed()
        {
            Assert.That(
                checkout.GetTitle(),
                Is.EqualTo("Checkout: Your Information")
            );
        }

        [Test]
        public void TC016_EmptyCheckoutFormShowsError()
        {
            checkout.Continue();

            Assert.That(
                checkout.GetErrorMessage(),
                Does.Contain("First Name is required")
            );
        }

        [Test]
        public void TC017_MissingLastNameShowsError()
        {
            checkout.EnterFirstName("Shivani");
            checkout.EnterLastName("");
            checkout.EnterPostalCode("5000");

            checkout.Continue();

            Wait.Until(driver =>
                driver.FindElements(
                    By.CssSelector("[data-test='error']")
                ).Any()
            );

            Assert.That(
                checkout.GetErrorMessage(),
                Does.Contain("Last Name is required")
            );
        }

        [Test]
        public void TC018_MissingPostalCodeShowsError()
        {
            checkout.EnterFirstName("Shivani");
            checkout.EnterLastName("Tester");

            checkout.Continue();

            Assert.That(
                checkout.GetErrorMessage(),
                Does.Contain("Postal Code is required")
            );
        }
    }
}
