
using OpenQA.Selenium;

namespace SauceDemo.Tests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void EnterUsername(string username) =>
            driver.FindElement(By.Id("user-name")).SendKeys(username);

        public void EnterPassword(string password) =>
            driver.FindElement(By.Id("password")).SendKeys(password);

        public void ClickLogin() =>
            driver.FindElement(By.Id("login-button")).Click();

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }

        public string GetErrorMessage() =>
            driver.FindElement(By.CssSelector("[data-test='error']")).Text;

        public bool IsLoginButtonDisplayed() =>
            driver.FindElement(By.Id("login-button")).Displayed;
    }
}
