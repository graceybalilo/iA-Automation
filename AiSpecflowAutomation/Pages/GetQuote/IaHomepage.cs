using NUnit.Framework;
using OpenQA.Selenium;

namespace AiSpecflowAutomation.Pages.GetQuote
{
    public class IaHomepage : BasePage
    {

        #region Page Objects

        private const string PageUrl = "https://ia.ca/individuals";
        private const string PageTitle = "iA Financial Group - Industrial Alliance | Insurance and Savings";
        private readonly string _actualTitle;
        private readonly By _details = By.XPath("//p[contains(text(),'Use them to guide you through your savings and ins')]");
        private readonly By _getQuote = By.XPath("//span[@class='label']");
        private readonly By _lifeInsurance = By.XPath("//li[contains(text(), 'Life insurance')]");
        private readonly By _yourNeeds = By.XPath("//a[@href='https://ia.ca/life-insurance-calculator']");
        private readonly By _cookiesButton = By.XPath("//button[@class='banniereCookies-button js-cookieBanner-btn']");
        private readonly By _homeInsurance = By.XPath("//li[contains(text(), \"Home insurance\")]");
        private readonly By _homeInsurancePop = By.XPath("//div[@data-id='zone-contenu-modal']");
        #endregion

        public IaHomepage(IWebDriver driver)
        {
            this._driver = driver;
            _actualTitle = driver.Title;
        }

        public IaHomepage Verify() 
        {
            Assert.AreEqual(true, _actualTitle.Contains(PageTitle), "Page title is incorrect!"); 
            return this;
        }
        public IaHomepage NavigateToHomePage() 
        {
            NavigateToUrl(PageUrl);
            return this;
        }

        public IaHomepage AcceptCookie()
        {
            Click(_cookiesButton); 
            return this;
        }
        public IaHomepage ClickGetAQuoteButton()
        {
            Scroll(_details);
            Thread.Sleep(1000);
            Highlight(_getQuote);
            Click(_getQuote);
            return this;
        }

        public IaHomepage ClickLifeInsurance()
        {

            Thread.Sleep(1000);
            Scroll(_lifeInsurance);

            Highlight(_lifeInsurance);
            Click(_lifeInsurance);
            return this;
        }

        public IaHomepage ClickHomeInsurance() 
        {
            Thread.Sleep(1000);
            Scroll(_homeInsurance);
            Highlight(_homeInsurance);
            Click(_homeInsurance);
            return this;
        }

        public IaHomepage VerifyHomeInsurancePopup() 
        {
            Thread.Sleep(1000);
            Highlight(_homeInsurancePop);
            return this;
        }
        public IaLifeInsuranceCalcpage ClickDetermineYourNeeds()
        {
            Highlight(_yourNeeds);
            Click(_yourNeeds);
            return new IaLifeInsuranceCalcpage(_driver);
        }
    }
}
