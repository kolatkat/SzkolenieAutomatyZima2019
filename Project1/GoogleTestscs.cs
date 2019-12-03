

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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

        [Fact]
        public void Can_add_new_comment()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/");
            var firstParagraph = browser.FindElement(By.LinkText("ghfjhjhvjhvjh"));
            firstParagraph.Click();

           var comment =  browser.FindElement(By.Id("comment"));
            //comment.Click();
            comment.SendKeys("Mój komentarz (kasia kurs grudzień)");
            var autor = browser.FindElement(By.Id("author"));
            //autor.Click();
            autor.SendKeys("Kate");
            var mail = browser.FindElement(By.Id("email"));
            //mail.Click();
            mail.SendKeys("testTest@test.pl");

            MoveToElement(browser.FindElement(By.ClassName("meta-nav")));

            var sendComments = browser.FindElement(By.Id("submit"));
            sendComments.Click();

            //var result = 
        }

        public void Dispose()
        {
            browser.Quit();
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
    }
}
