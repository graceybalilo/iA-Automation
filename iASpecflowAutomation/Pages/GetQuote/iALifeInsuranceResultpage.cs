using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iASpecflowAutomation.Pages.GetQuote
{
    public class iALifeInsuranceResultpage : BasePage
    {
        public iALifeInsuranceResultpage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Page Objects
        private By yourEstimateText = By.XPath("//h2[@id='result-assurance-title']");
        private By insuranceAmnt = By.XPath("//div[@class='bloc bloc-resultat']//div[@class='row']//div[1]");
        private By insuranceCost = By.XPath("//div[@class='bloc bloc-resultat']//div[2]");
        private string pageTitle = "Term life insurance calculator | iA Financial Group";
        private string actualTitle;
        #endregion



        public iALifeInsuranceResultpage verifyResult()
        {
            actualTitle = driver.Title;
            Assert.AreEqual(true, actualTitle.Contains(pageTitle), "Page title is incorrect!");

            Scroll(yourEstimateText);

            Highlight(yourEstimateText);
            Assert.IsTrue(FindElement(yourEstimateText).Displayed);

            Highlight(insuranceAmnt);
            Assert.IsTrue(FindElement(insuranceAmnt).Displayed);

            Highlight(insuranceCost);
            Assert.IsTrue(FindElement(insuranceCost).Displayed);

            return this;
        }

    }
}
