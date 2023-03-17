using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace AiSpecflowAutomation.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver = default!;

        //Common method for navigation to url
        protected BasePage NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            return this;
        }

        //Common method that will return the locator as an element
        protected IWebElement FindElement(By element)
        {
            return _driver.FindElement(element);
        }

        //Common method fo clicking an element
        protected BasePage Click(By element)
        {
            FindElement(element).Click();
            return this;
        }

        //Common method for entering a text in a textbox element
        protected BasePage EnterText(By element, string text)
        {
            FindElement(element).SendKeys(text);
            return this;
        }

        //Common method for highlighting an element
        protected BasePage Highlight(By element) 
        {
            var highlight = _driver.FindElement(element);

            _driver.ExecuteJavaScript("arguments[0].style.border='5px solid red'", highlight);
            Thread.Sleep(1000);
            return this;
        }

        //Common method for scrolling before doing an action
        protected BasePage Scroll(By element) 
        {
            var scroll = _driver.FindElement(element);

            _driver.ExecuteJavaScript("arguments[0].scrollIntoView(true)", scroll);
            return this;
        }

    }
}
