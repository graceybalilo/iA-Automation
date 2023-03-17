using OpenQA.Selenium;

namespace iASpecflowAutomation.Pages
{
    public class BasePage
    {
        public IWebDriver driver;

        //Common method for navigation to url
        public BasePage NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        //Common method that will return the locator as an element
        public IWebElement FindElement(By element)
        {
            return driver.FindElement(element);
        }

        //Common method fo clicking an element
        public BasePage Click(By element)
        {
            FindElement(element).Click();
            return this;
        }

        //Common method for entering a text in a textbox element
        public BasePage EnterText(By element, string text)
        {
            FindElement(element).SendKeys(text);
            return this;
        }

        //Common method for highlighting an element
        public BasePage Highlight(By element) 
        {
            IWebElement highlight = driver.FindElement(element);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='5px solid red'", highlight);
            Thread.Sleep(1000);
            return this;
        }

        //Common method for scrolling before doing an action
        public BasePage Scroll(By element) 
        {
            IWebElement scroll = driver.FindElement(element);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", scroll);
            return this;
        }

    }
}
