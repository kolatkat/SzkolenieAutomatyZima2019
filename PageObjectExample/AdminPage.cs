using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace PageObjectsExample
{
    internal class AdminPage
    {
        private IWebDriver browser;

        public AdminPage(IWebDriver browser)
        {
            this.browser = browser;
        }
        internal string AddCommentNotes(ExampleComment exampleComment)
        {
            var note = browser.FindElement(By.LinkText("Wpisy"));
                note.Click();
            var newNote = browser.FindElement(By.LinkText("Dodaj nowy"));
                newNote.Click();

            var title = browser.FindElement(By.Name("post_title"));
                title.SendKeys(exampleComment.Title);
            var comment = browser.FindElement(By.Id("content"));
                comment.SendKeys(exampleComment.Content);
            var publish = browser.FindElement(By.Id("publish"));
                publish.Click();

            WaitForClickable(By.CssSelector("#sample-permalink > a"), 5);

            var link = browser.FindElement(By.CssSelector("#sample-permalink > a"));
            var linkText = link.GetAttribute("href");

            return linkText;
                      
            
        } 

        internal void LogOut()
        {
            var displayName = browser.FindElement(By.Id("wp-admin-bar-my-account"));
            MoveToElement(displayName);
            
            WaitForClickable(By.PartialLinkText("Wyloguj się"), 5);
            var getOut = browser.FindElement(By.PartialLinkText("Wyloguj się"));
            getOut.Click();

            

        }
        
        internal bool Has(ExampleComment exampleComment)
            {
            var publishTitle = browser.FindElements(By.CssSelector(".entry_title"));
            var mypublishTitle = publishTitle
                    .Where( c => c.FindElement(By.CssSelector(".fn")).Text == exampleComment.Author);


            var publishContent = browser.FindElement(By.CssSelector(""));


            return false;
            }
        internal void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
        internal void MoveToElement(By selector)
        {
            var element = browser.FindElement(selector);
            MoveToElement(element);
        }
        internal void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
    }
}