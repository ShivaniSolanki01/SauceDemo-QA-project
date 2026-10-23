
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Tests.Base
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver = null!;
        protected WebDriverWait Wait = null!;

        [SetUp]
        public void SetUpBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();

            Wait = new WebDriverWait(
                Driver,
                TimeSpan.FromSeconds(10)
            );

            Wait.IgnoreExceptionTypes(
                typeof(StaleElementReferenceException)
            );
        }

        protected void WaitForVisible(By locator)
        {
            Wait.Until(driver =>
            {
                var elements = driver.FindElements(locator);

                return elements.Count > 0 && elements[0].Displayed;
            });
        }

        [TearDown]
        public void CloseBrowser()
        {
            try
            {
                Driver?.Quit();
            }
            finally
            {
                Driver?.Dispose();
            }
        }
    }
}
