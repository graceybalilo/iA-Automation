using NUnit.Framework;
using OpenQA.Selenium;

namespace AiSpecflowAutomation.Pages.GetQuote
{
    public class IaLifeInsuranceCalcpage : BasePage
    {
        public IaLifeInsuranceCalcpage(IWebDriver driver)
        {
            this._driver = driver;
        }

        #region Page Objects
        private readonly By _aboutYouText = By.XPath("//h2[@id='portraitGeneral']");
        private readonly By _womanButton = By.XPath("//label[@for='calcvie-sexe-f']");
        private readonly By _manButton = By.XPath("//label[@for='calcvie-sexe-h']");
        private readonly By _genderErrorMessage = By.XPath("//label[@id='calcvie-sexe-h_error']");
        private readonly By _coupleButton = By.XPath("//label[@for='calcvie-couple-cpl']");
        private readonly By _singleButton = By.XPath("//label[@for='calcvie-couple-cel']");
        private readonly By _statusErrorMessage = By.XPath("//label[@id='calcvie-couple-cel_error']");
        private readonly By _smokerButton = By.XPath("//label[@for='calcvie-fumeur-f']");
        private readonly By _notASmokerButton = By.XPath("//label[@for='calcvie-fumeur-nf']");
        private readonly By _vicesErrorMessage = By.XPath("//label[@id='calcvie-fumeur-f_error']");
        private readonly By _birthdate = By.Id("calvie-date");
        private readonly By _birthdayErrorMessage = By.XPath("//label[@id='calvie-age_error']");
        private readonly By _yesButton = By.XPath("//label[@for='calcvie-besoin-connu']");
        private readonly By _errorMessage = By.XPath("//label[@id='calcvie-besoin-connu_error']");
        private readonly By _amountTextbox = By.XPath("//input[@name='calcvie-montantsouhaite']");
        private readonly By _amountErrorMessage = By.XPath("//label[@id='calcvie-sexe-h_error']");
        private readonly By _calculateButton = By.Id("btn-calculer");
        private const string PageTitle = "Term life insurance calculator | iA Financial Group";
        private string actualTitle = default!;
        #endregion


        public IaLifeInsuranceCalcpage ClickFieldsforCoupleWoman()
        {

            actualTitle = _driver.Title;
            Assert.AreEqual(true, actualTitle.Contains(PageTitle), "Page title is incorrect!");
            Scroll(_aboutYouText);

            Highlight(_womanButton);
            Click(_womanButton);

            Highlight(_coupleButton);
            Click(_coupleButton);

            Highlight(_smokerButton);
            Click(_smokerButton);
            Click(_yesButton);
            Thread.Sleep(1000);
            return this;
        }

        public IaLifeInsuranceCalcpage ClickFieldsForSingleWoman()
        {

            Highlight(_womanButton);
            Click(_womanButton);

            Highlight(_singleButton);
            Click(_singleButton);

            Highlight(_smokerButton);
            Click(_smokerButton);
            Click(_yesButton);
            Thread.Sleep(1000);
            return this;
        }

        public IaLifeInsuranceCalcpage ClickFieldsForSingleNonSmokerWoman()
        {

            Highlight(_womanButton);
            Click(_womanButton);

            Highlight(_singleButton);
            Click(_singleButton);

            Highlight(_notASmokerButton);
            Click(_notASmokerButton);
            Click(_yesButton);
            Thread.Sleep(1000);
            return this;
        }

        public IaLifeInsuranceCalcpage ClickFieldsForSingleSmokerMan()
        {

            Highlight(_manButton);
            Click(_manButton);

            Highlight(_singleButton);
            Click(_singleButton);

            Highlight(_notASmokerButton);
            Click(_smokerButton);
            Click(_yesButton);
            Thread.Sleep(1000);
            return this;
        }

        public IaLifeInsuranceCalcpage ClickFieldsForSingleNonSmokerMan()
        {

            Highlight(_manButton);
            Click(_manButton);

            Highlight(_singleButton);
            Click(_singleButton);

            Highlight(_smokerButton);
            Click(_notASmokerButton);
            Click(_yesButton);
            Thread.Sleep(1000);
            return this;
        }

        public IaLifeInsuranceCalcpage ClickFieldsForCoupleNonSmokerMan()
        {

            Highlight(_manButton);
            Click(_manButton);

            Highlight(_coupleButton);
            Click(_coupleButton);

            Highlight(_notASmokerButton);
            Click(_notASmokerButton);
            Click(_yesButton);
            Thread.Sleep(1000);
            return this;
        }

        public IaLifeInsuranceCalcpage ClickFieldsForCoupleSmokerMan()
        {

            Highlight(_manButton);
            Click(_manButton);

            Highlight(_coupleButton);
            Click(_coupleButton);

            Highlight(_smokerButton);
            Click(_smokerButton);
            Click(_yesButton);
            Thread.Sleep(1000);
            return this;
        }

        public IaLifeInsuranceCalcpage PopulateFields(string birthDate, string amount)
        {
            Highlight(_birthdate);
            EnterText(_birthdate, birthDate);
            Highlight(_amountTextbox);
            EnterText(_amountTextbox, amount);
            return this;
        }

        public IaLifeInsuranceCalcpage DoNotClickAnything() 
        {
            Scroll(_aboutYouText);
            return this;
        }
        public IaLifeInsuranceCalcpage ValidateErrorMessage() 
        {
            Scroll(_aboutYouText);

            Highlight(_genderErrorMessage);
            Assert.IsTrue(FindElement(_genderErrorMessage).Displayed);

            Highlight(_statusErrorMessage);
            Assert.IsTrue(FindElement(_statusErrorMessage).Displayed);

            Highlight(_vicesErrorMessage);
            Assert.IsTrue(FindElement(_vicesErrorMessage).Displayed);

            Highlight(_birthdayErrorMessage);
            Assert.IsTrue(FindElement(_birthdayErrorMessage).Displayed);
            
            Scroll(_yesButton);

            Highlight(_errorMessage);
            Assert.IsTrue(FindElement(_errorMessage).Displayed);
            return this;
        }

        public IaLifeInsuranceCalcpage CalculateEmpty()
        {
            Highlight(_calculateButton);
            Click(_calculateButton);
            Thread.Sleep(3000);
            return this;
        }

        public AiLifeInsuranceResultpage Calculate()
        {
            Highlight(_calculateButton);
            Click(_calculateButton);
            Thread.Sleep(3000);
            return new AiLifeInsuranceResultpage(_driver);
        }

    }
}
