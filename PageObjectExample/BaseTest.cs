using OpenQA.Selenium;
using System;

namespace PageObjectsExample
{
    public abstract class BaseTest : IDisposable
    {
        private readonly IWebDriver browser;

        public BaseTest()
        {
            browser = DriverFactory.Get();
        }

        public IWebDriver GetBrowser()
        {
            return browser;
        }
        public void Dispose()
        {
           if ( browser != null)
            {
                browser.Quit();
            }
        }
    }
}