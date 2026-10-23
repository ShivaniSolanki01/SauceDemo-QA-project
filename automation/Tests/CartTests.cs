
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo.Tests.Base;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests.Tests
{
    public class CartTests : BaseTest
    {
        private LoginPage login = null!;
        private ProductsPage products = null!;
        private CartPage cart = null!;

        [SetUp]
        public void SetUpCart()
        {
            login = new LoginPage(Driver);
            products = new ProductsPage(Driver);
            cart = new CartPage(Driver);

            login.Open();
            login.Login("standard_user", "secret_sauce");
            WaitForVisible(By.ClassName("inventory_list"));
        }

        [Test]
        public void TC010_AddOneItem()
        {
            products.AddBackpackToCart();
            products.OpenCart();

            WaitForVisible(By.ClassName("cart_item"));

            var itemName = Wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(
                        By.ClassName("inventory_item_name"));

                    return element.Text;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });

            Assert.That(
                itemName,
                Is.EqualTo("Sauce Labs Backpack"),
                "The backpack should appear in the shopping cart."
            );
        }


        [Test]
        public void TC011_AddMultipleItems()
        {
            products.AddBackpackToCart();
            products.AddBikeLightToCart();

            Assert.That(products.GetCartBadge(), Is.EqualTo("2"));
        }

        [Test]
        public void TC012_RemoveItem()
        {
            products.AddBackpackToCart();
            products.RemoveBackpackFromCart();

            Assert.That(Driver.FindElements(
                By.ClassName("shopping_cart_badge")).Count, Is.EqualTo(0));
        }

        [Test]
        public void TC013_CartBadgeShowsQuantity()
        {
            products.AddBackpackToCart();
            Assert.That(products.GetCartBadge(), Is.EqualTo("1"));
        }

        [Test]
        public void TC014_ContinueShoppingReturnsToProducts()
        {
            products.AddBackpackToCart();
            products.OpenCart();
            cart.ContinueShopping();

            Assert.That(Driver.Url, Does.Contain("inventory.html"));
        }
    }
}
