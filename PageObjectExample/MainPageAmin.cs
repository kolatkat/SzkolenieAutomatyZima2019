using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectsExample
{
    internal class MainPageAdmin
    {
        private const string MAIN_PAGE_BASE_URL = "http://automatyzacja.benedykt.net/wp-admin";
        private readonly IWebDriver browser;


        private MainPageAdmin(IWebDriver browser)
        {
            this.browser = browser;
            browser.Navigate().GoToUrl(MAIN_PAGE_BASE_URL);
        }
        internal static MainPageAdmin Open(IWebDriver browser)
        {
            return new MainPageAdmin(browser);
        }

        internal AdminPage NavigateToAdminPanel()
        {
            WaitForClickable(By.Id("user_login"), 5);

            var login = browser.FindElement(By.Id("user_login"));
            login.SendKeys("automatyzacja");

            var password = browser.FindElement(By.Id("user_pass"));
            password.SendKeys("auto@Zima2019");

            var logon = browser.FindElement(By.Id("wp-submit"));
            logon.Click();


            return new AdminPage(browser);
        }

        internal void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}