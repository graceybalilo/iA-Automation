using NUnit.Framework;
using OpenQA.Selenium;

namespace iASpecflowAutomation.Pages.GetQuote
{
    public class iAHomepage : BasePage
    {

        #region Page Objects
        private string pageUrl = "https://ia.ca/individuals";
        private string pageTitle = "iA Financial Group - Industrial Alliance | Insurance and Savings";
        private string actualTitle;
        private By details = By.XPath("//p[contains(text(),'Use them to guide you through your savings and ins')]");
        private By getQuote = By.XPath("//span[@class='label']");
        private By lifeInsurance = By.XPath("//li[contains(text(), 'Life insurance')]");
        private By yourNeeds = By.XPath("//a[@href='https://ia.ca/life-insurance-calculator']");
        private By btnCookies = By.XPath("//button[@class='banniereCookies-button js-cookieBanner-btn']");
        private By homeInsurance = By.XPath("//li[contains(text(), \"Home insurance\")]");
        private By homeInsurancePop = By.XPath("//div[@data-id='zone-contenu-modal']");
        #endregion

        public iAHomepage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public iAHomepage Verify() 
        {
            actualTitle = driver.Title;
            Assert.AreEqual(true, actualTitle.Contains(pageTitle), "Page title is incorrect!"); 
            return this;
        }
        public iAHomepage NavigateToHomePage() 
        {
            NavigateToUrl(pageUrl);
            return this;
        }

        public iAHomepage acceptCookie()
        {
            Click(btnCookies); 
            return this;
        }
        public iAHomepage ClickGetAQuoteButton()
        {
            Scroll(details);
            Thread.Sleep(1000);
            Highlight(getQuote);
            Click(getQuote);
            return this;
        }

        public iAHomepage ClickLifeInsurance()
        {

            Thread.Sleep(1000);
            Scroll(lifeInsurance);

            Highlight(lifeInsurance);
            Click(lifeInsurance);
            return this;
        }

        public iAHomepage ClickHomeInsurance() 
        {
            Thread.Sleep(1000);
            Scroll(homeInsurance);
            Highlight(homeInsurance);
            Click(homeInsurance);
            return this;
        }

        public iAHomepage VerifyHomeInsurancePopup() 
        {
            Thread.Sleep(1000);
            Highlight(homeInsurancePop);
            return this;
        }
        public iALifeInsuranceCalcpage ClickDetermineYourNeeds()
        {
            Highlight(yourNeeds);
            Click(yourNeeds);
            return new iALifeInsuranceCalcpage(driver);
        }
    }
}
