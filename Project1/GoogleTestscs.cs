

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
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
            var latesNote = browser.FindElement(By.CssSelector(".entry-title > a"));
            latesNote.Click();

            //r firstNote = browser.FindElement(By.CssSelector(".entry-title"));

           var comment =  browser.FindElement(By.Id("comment"));
           var examplText = Faker.Lorem.Paragraph();
            comment.SendKeys(examplText);

            var author = browser.FindElement(By.Id("author"));
            var exampleAUthor = Faker.Name.FullName();
            author.SendKeys(exampleAUthor);

            var email = browser.FindElement(By.Id("email"));
            var exampleEmail = Faker.Internet.Email();
            email.SendKeys(exampleEmail);

            MoveToElement(browser.FindElement(By.ClassName("meta-nav")));

            browser.FindElement(By.Id("submit")).Submit();

            var comments = browser.FindElements(By.CssSelector("article.comment-body"));
            var myComments = comments
                    .Where(c => c.FindElement(By.CssSelector(".fn")).Text == exampleAUthor)
                    .Where( c => c.FindElement(By.CssSelector(".comment-content > p" )).Text == examplText);

            Assert.Single(myComments);
            

            /*comment.SendKeys("Mój komentarz (kasia kurs grudzień)");

        var autor = browser.FindElement(By.Id("author"));
            autor.SendKeys("Kate");

         var mail = browser.FindElement(By.Id("email"));
             mail.SendKeys("testTest@test.pl");

         MoveToElement(browser.FindElement(By.ClassName("meta-nav")));

         var sendComments = browser.FindElement(By.Id("submit"));
         sendComments.Click(); */

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
