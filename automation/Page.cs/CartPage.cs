
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Tests.Pages
{
    public class CartPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(
                driver,
                TimeSpan.FromSeconds(10)
            );

            wait.IgnoreExceptionTypes(
                typeof(StaleElementReferenceException)
            );
        }

        public List<string> GetItemNames()
        {
            return wait.Until(d =>
            {
                var rows = d.FindElements(By.ClassName("cart_item"));

                if (rows.Count == 0)
                    return null;

                var names = new List<string>();

                foreach (var row in rows)
                {
                    names.Add(
                        row.FindElement(
                            By.ClassName("inventory_item_name")
                        ).Text
                    );
                }

                return names;
            })!;
        }

        public bool ContainsItem(string name)
        {
            return GetItemNames().Contains(name);
        }

        public void RemoveBackpack()
        {
            var button = wait.Until(d =>
            {
                var elements = d.FindElements(
                    By.Id("remove-sauce-labs-backpack")
                );

                return elements.Count > 0 &&
                       elements[0].Displayed &&
                       elements[0].Enabled
                    ? elements[0]
                    : null;
            });

            button.Click();
        }

        public void ContinueShopping()
        {
            var button = wait.Until(d =>
            {
                var elements = d.FindElements(
                    By.Id("continue-shopping")
                );

                return elements.Count > 0 &&
                       elements[0].Displayed &&
                       elements[0].Enabled
                    ? elements[0]
                    : null;
            });

            button.Click();
        }

        public void Checkout()
        {
            var button = wait.Until(d =>
            {
                var elements = d.FindElements(By.Id("checkout"));

                return elements.Count > 0 &&
                       elements[0].Displayed &&
                       elements[0].Enabled
                    ? elements[0]
                    : null;
            });

            button.Click();
        }

        public bool IsEmpty()
        {
            return driver.FindElements(
                By.ClassName("cart_item")
            ).Count == 0;
        }
    }
}
