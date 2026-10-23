
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo.Tests.Base;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests.Tests
{
    public class LoginTests : BaseTest
    {
        private LoginPage login = null!;

        [SetUp]
        public void SetUpLoginPage()
        {
            login = new LoginPage(Driver);
            login.Open();
        }

        [Test]
        public void TC001_ValidLogin()
        {
            login.Login("standard_user", "secret_sauce");
            WaitForVisible(By.ClassName("inventory_list"));

            Assert.That(Driver.Url, Does.Contain("inventory.html"));
        }

        [Test]
        public void TC002_InvalidPassword()
        {
            login.Login("standard_user", "wrong_password");

            Assert.That(login.GetErrorMessage(),
                Does.Contain("Username and password do not match"));
        }

        [Test]
        public void TC003_LockedOutUser()
        {
            login.Login("locked_out_user", "secret_sauce");

            Assert.That(login.GetErrorMessage(), Does.Contain("locked out"));
        }

        [Test]
        public void TC004_EmptyUsername()
        {
            login.Login("", "secret_sauce");

            Assert.That(login.GetErrorMessage(),
                Does.Contain("Username is required"));
        }
    }
}
