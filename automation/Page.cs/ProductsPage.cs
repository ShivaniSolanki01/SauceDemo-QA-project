
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Tests.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver driver;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsDisplayed() =>
            driver.FindElement(By.ClassName("inventory_list")).Displayed;

        public string GetTitle() =>
            driver.FindElement(By.ClassName("title")).Text;

        public void SortBy(string value)
        {
            var dropdown = new SelectElement(
                driver.FindElement(By.ClassName("product_sort_container"))
            );

            dropdown.SelectByValue(value);
        }

        public List<string> GetProductNames() =>
            driver.FindElements(By.ClassName("inventory_item_name"))
                  .Select(e => e.Text)
                  .ToList();

        public List<decimal> GetProductPrices() =>
            driver.FindElements(By.ClassName("inventory_item_price"))
                  .Select(e => decimal.Parse(e.Text.Replace("$", "")))
                  .ToList();

        public void AddBackpackToCart() =>
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();

        public void AddBikeLightToCart() =>
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();

        public void RemoveBackpackFromCart() =>
            driver.FindElement(By.Id("remove-sauce-labs-backpack")).Click();

        public string GetCartBadge() =>
            driver.FindElement(By.ClassName("shopping_cart_badge")).Text;

        public void OpenCart() =>
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();

        public void Logout()
        {
            var wait = new WebDriverWait(
                driver,
                TimeSpan.FromSeconds(10)
            );

            var menuButton = wait.Until(d =>
            {
                var elements = d.FindElements(
                    By.Id("react-burger-menu-btn")
                );

                return elements.Count > 0 &&
                       elements[0].Displayed &&
                       elements[0].Enabled
                    ? elements[0]
                    : null;
            });

            menuButton.Click();

            var logoutLink = wait.Until(d =>
            {
                var elements = d.FindElements(
                    By.Id("logout_sidebar_link")
                );

                return elements.Count > 0 &&
                       elements[0].Displayed &&
                       elements[0].Enabled
                    ? elements[0]
                    : null;
            });

            logoutLink.Click();
        }
    }
}
