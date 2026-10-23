
using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo.Tests.Base;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests.Tests
{
    public class ProductTests : BaseTest
    {
        private LoginPage login = null!;
        private ProductsPage products = null!;

        [SetUp]
        public void SetUpProducts()
        {
            login = new LoginPage(Driver);
            products = new ProductsPage(Driver);

            login.Open();
            login.Login("standard_user", "secret_sauce");

            WaitForVisible(By.ClassName("inventory_list"));
        }

        [Test]
        public void TC005_ProductsPageDisplayed()
        {
            Assert.That(products.IsDisplayed(), Is.True);
            Assert.That(products.GetTitle(), Is.EqualTo("Products"));
        }

        [Test]
        public void TC006_SortNameAscending()
        {
            products.SortBy("az");

            Wait.Until(driver =>
                products.GetProductNames().SequenceEqual(
                    products.GetProductNames()
                        .OrderBy(x => x, StringComparer.Ordinal)
                )
            );

            var names = products.GetProductNames();

            Assert.That(
                names,
                Is.EqualTo(names.OrderBy(x => x, StringComparer.Ordinal))
            );
        }

        [Test]
        public void TC007_SortNameDescending()
        {
            products.SortBy("za");

            Wait.Until(driver =>
                products.GetProductNames().SequenceEqual(
                    products.GetProductNames()
                        .OrderByDescending(x => x, StringComparer.Ordinal)
                )
            );

            var names = products.GetProductNames();

            Assert.That(
                names,
                Is.EqualTo(names.OrderByDescending(x => x, StringComparer.Ordinal))
            );
        }

        [Test]
        public void TC008_SortPriceLowToHigh()
        {
            products.SortBy("lohi");

            Wait.Until(driver =>
                products.GetProductPrices().SequenceEqual(
                    products.GetProductPrices().OrderBy(x => x)
                )
            );

            var prices = products.GetProductPrices();

            Assert.That(prices, Is.EqualTo(prices.OrderBy(x => x)));
        }

        [Test]
        public void TC009_SortPriceHighToLow()
        {
            products.SortBy("hilo");

            Wait.Until(driver =>
                products.GetProductPrices().SequenceEqual(
                    products.GetProductPrices().OrderByDescending(x => x)
                )
            );

            var prices = products.GetProductPrices();

            Assert.That(
                prices,
                Is.EqualTo(prices.OrderByDescending(x => x))
            );
        }
    }
}
