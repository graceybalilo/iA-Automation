using NUnit.Framework;
using OpenQA.Selenium;

namespace AiSpecflowAutomation.Pages.GetQuote
{
    public class AiLifeInsuranceResultpage : BasePage
    {
        public AiLifeInsuranceResultpage(IWebDriver driver)
        {
            this._driver = driver;
        }

        #region Page Objects
        private readonly By _yourEstimateText = By.XPath("//h2[@id='result-assurance-title']");
        private readonly By _insuranceAmnt = By.XPath("//div[@class='bloc bloc-resultat']//div[@class='row']//div[1]");
        private readonly By _insuranceCost = By.XPath("//div[@class='bloc bloc-resultat']//div[2]");
        private const string PageTitle = "Term life insurance calculator | iA Financial Group";
        private string actualTitle = default!;
        #endregion



        public AiLifeInsuranceResultpage verifyResult()
        {
            actualTitle = _driver.Title;
            Assert.AreEqual(true, actualTitle.Contains(PageTitle), "Page title is incorrect!");

            Scroll(_yourEstimateText);

            Highlight(_yourEstimateText);
            Assert.IsTrue(FindElement(_yourEstimateText).Displayed);

            Highlight(_insuranceAmnt);
            Assert.IsTrue(FindElement(_insuranceAmnt).Displayed);

            Highlight(_insuranceCost);
            Assert.IsTrue(FindElement(_insuranceCost).Displayed);

            return this;
        }

    }
}
