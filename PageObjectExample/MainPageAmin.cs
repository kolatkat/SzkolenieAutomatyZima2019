using OpenQA.Selenium;

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
    }
}