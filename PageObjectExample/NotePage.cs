using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjectsExample
{
    internal class NotePage
    {
        private IWebDriver browser;
        private string link;

        public NotePage(IWebDriver browser)
        {
            this.browser = browser;
        }

        public NotePage(IWebDriver browser, string link) : this(browser)
        {
            this.link = link;
            browser.Navigate().GoToUrl(link);
        }

        internal NotePage AddComment(ExampleComment exampleComment)
        {
            var comment = browser.FindElement(By.Id("comment"));
            comment.SendKeys(exampleComment.Content);

            var author = browser.FindElement(By.Id("author"));           
            author.SendKeys(exampleComment.Author);

            var email = browser.FindElement(By.Id("email"));
            email.SendKeys(exampleComment.Email);

            MoveToElement(browser.FindElement(By.ClassName("meta-nav")));

            browser.FindElement(By.Id("submit")).Submit();
            return new NotePage(browser);
        }

        internal bool Has(ExampleComment exampleComment)
        {
            var comments = browser.FindElements(By.CssSelector("article.comment-body"));
            var myComments = comments
                    .Where(c => c.FindElement(By.CssSelector(".fn")).Text == exampleComment.Author)
                    .Where(c => c.FindElement(By.CssSelector(".comment-content > p")).Text == exampleComment.Content);

            return myComments.Count() == 1;
        }

        internal bool HasMyNotes(ExampleComment exampleComment)
        {
            var myTitle = browser.FindElement(By.CssSelector(".entry-title"));
            var myContent = browser.FindElement(By.CssSelector(".entry-content > p"));

            return myTitle.Text == exampleComment.Title && myContent.Text == exampleComment.Content;
                
        }

        public NotePage GoTo(string link)
        {
            browser.Navigate().GoToUrl(link);
            return new NotePage(browser);
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
    }
}