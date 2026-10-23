
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Tests.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public CheckoutPage(IWebDriver driver)
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

        public void EnterFirstName(string value) =>
            driver.FindElement(By.Id("first-name")).SendKeys(value);

        public void EnterLastName(string value) =>
            driver.FindElement(By.Id("last-name")).SendKeys(value);

        public void EnterPostalCode(string value) =>
            driver.FindElement(By.Id("postal-code")).SendKeys(value);

        public void Continue()
        {
            var button = wait.Until(d =>
            {
                var elements = d.FindElements(By.Id("continue"));

                return elements.Count > 0 &&
                       elements[0].Displayed &&
                       elements[0].Enabled
                    ? elements[0]
                    : null;
            });

            button.Click();
        }

        public string GetErrorMessage()
        {
            return wait.Until(d =>
            {
                var elements = d.FindElements(
                    By.CssSelector("[data-test='error']")
                );

                return elements.Count > 0 && elements[0].Displayed
                    ? elements[0].Text
                    : null;
            })!;
        }

        public string GetTitle() =>
            driver.FindElement(By.ClassName("title")).Text;

        public bool IsOverviewDisplayed() =>
            driver.FindElements(By.ClassName("summary_info")).Count > 0;

        public void FinishOrder() =>
            driver.FindElement(By.Id("finish")).Click();

        public string GetConfirmationMessage() =>
            driver.FindElement(By.ClassName("complete-header")).Text;

        public void BackHome() =>
            driver.FindElement(By.Id("back-to-products")).Click();
    }
}
