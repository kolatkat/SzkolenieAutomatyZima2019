

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace Project1
{
    public class GoogleTestscs: System.IDisposable
    {
        IWebDriver browser;

        public GoogleTestscs()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void CanGoogleWeatherForWarsaw()
        {
            browser.Navigate().GoToUrl("https://google.com");
            var queryBox = browser.FindElement(By.Name("q"));
            queryBox.Click();
            queryBox.SendKeys("pogoda warszawa");
            queryBox.Submit();

            var result = browser.FindElement(By.Id("wob_tm"));

            Assert.Equal("3", result.Text);

            
        }

        public void Dispose()
        {
            browser.Quit();
        }
    }
}
