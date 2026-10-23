
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo.Tests.Base;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests.Tests
{
    public class OrderTests : BaseTest
    {
        private LoginPage login = null!;
        private ProductsPage products = null!;
        private CartPage cart = null!;
        private CheckoutPage checkout = null!;

        [SetUp]
        public void SetUpOrder()
        {
            login = new LoginPage(Driver);
            products = new ProductsPage(Driver);
            cart = new CartPage(Driver);
            checkout = new CheckoutPage(Driver);

            login.Open();
            login.Login("standard_user", "secret_sauce");

            WaitForVisible(By.ClassName("inventory_list"));

            products.AddBackpackToCart();
            products.OpenCart();

            WaitForVisible(By.ClassName("cart_item"));

            cart.Checkout();

            WaitForVisible(By.Id("first-name"));

            checkout.EnterFirstName("Shivani");
            checkout.EnterLastName("Tester");
            checkout.EnterPostalCode("5000");
            checkout.Continue();

            Wait.Until(driver =>
                driver.Url.Contains("checkout-step-two.html")
            );

            WaitForVisible(By.ClassName("summary_info"));
        }

        [Test]
        public void TC019_OrderOverviewDisplayed()
        {
            Assert.That(
                checkout.GetTitle(),
                Is.EqualTo("Checkout: Overview")
            );

            Assert.That(checkout.IsOverviewDisplayed(), Is.True);
        }

        [Test]
        public void TC020_FinishOrderShowsConfirmation()
        {
            checkout.FinishOrder();

            WaitForVisible(By.ClassName("complete-header"));

            Assert.That(
                checkout.GetConfirmationMessage(),
                Is.EqualTo("Thank you for your order!")
            );
        }

        [Test]
        public void TC021_BackHomeAfterOrderReturnsToProducts()
        {
            checkout.FinishOrder();

            WaitForVisible(By.ClassName("complete-header"));

            checkout.BackHome();

            WaitForVisible(By.ClassName("inventory_list"));

            Assert.That(Driver.Url, Does.Contain("inventory.html"));

            Assert.That(
                products.GetTitle(),
                Is.EqualTo("Products")
            );
        }
    }
}
