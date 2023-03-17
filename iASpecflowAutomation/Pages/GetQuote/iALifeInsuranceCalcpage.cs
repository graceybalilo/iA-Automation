using NUnit.Framework;
using OpenQA.Selenium;

namespace iASpecflowAutomation.Pages.GetQuote
{
    public class iALifeInsuranceCalcpage : BasePage
    {
        public iALifeInsuranceCalcpage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Page Objects
        private By txtAboutYou = By.XPath("//h2[@id='portraitGeneral']");
        private By btnWoman = By.XPath("//label[@for='calcvie-sexe-f']");
        private By btnMan = By.XPath("//label[@for='calcvie-sexe-h']");
        private By errorMsgGender = By.XPath("//label[@id='calcvie-sexe-h_error']");
        private By btnCouple = By.XPath("//label[@for='calcvie-couple-cpl']");
        private By btnSingle = By.XPath("//label[@for='calcvie-couple-cel']");
        private By errorMsgStatus = By.XPath("//label[@id='calcvie-couple-cel_error']");
        private By btnSmoker = By.XPath("//label[@for='calcvie-fumeur-f']");
        private By btnNSmoker = By.XPath("//label[@for='calcvie-fumeur-nf']");
        private By errorMsgVices = By.XPath("//label[@id='calcvie-fumeur-f_error']");
        private By birthdate = By.Id("calvie-date");
        private By errorMsgbday = By.XPath("//label[@id='calvie-age_error']");
        private By btnYes = By.XPath("//label[@for='calcvie-besoin-connu']");
        private By errorMsg = By.XPath("//label[@id='calcvie-besoin-connu_error']");
        private By amntTxtBox = By.XPath("//input[@name='calcvie-montantsouhaite']");
        private By errorMsgAmount = By.XPath("//label[@id='calcvie-sexe-h_error']");
        private By btnCalc = By.Id("btn-calculer");
        private string pageTitle = "Term life insurance calculator | iA Financial Group";
        private string actualTitle;
        #endregion


        #region Getters and Setters
        public string BirthDate { get; set; }
        public string Amount { get; set; }
        #endregion


        public iALifeInsuranceCalcpage ClickFieldsforCoupleWoman()
        {

            actualTitle = driver.Title;
            Assert.AreEqual(true, actualTitle.Contains(pageTitle), "Page title is incorrect!");
            Scroll(txtAboutYou);

            Highlight(btnWoman);
            Click(btnWoman);

            Highlight(btnCouple);
            Click(btnCouple);

            Highlight(btnSmoker);
            Click(btnSmoker);
            Click(btnYes);
            Thread.Sleep(1000);
            return this;
        }

        public iALifeInsuranceCalcpage ClickFieldsForSingleWoman()
        {

            Highlight(btnWoman);
            Click(btnWoman);

            Highlight(btnSingle);
            Click(btnSingle);

            Highlight(btnSmoker);
            Click(btnSmoker);
            Click(btnYes);
            Thread.Sleep(1000);
            return this;
        }

        public iALifeInsuranceCalcpage ClickFieldsForSingleNonSmokerWoman()
        {

            Highlight(btnWoman);
            Click(btnWoman);

            Highlight(btnSingle);
            Click(btnSingle);

            Highlight(btnNSmoker);
            Click(btnNSmoker);
            Click(btnYes);
            Thread.Sleep(1000);
            return this;
        }

        public iALifeInsuranceCalcpage ClickFieldsForSingleSmokerMan()
        {

            Highlight(btnMan);
            Click(btnMan);

            Highlight(btnSingle);
            Click(btnSingle);

            Highlight(btnNSmoker);
            Click(btnSmoker);
            Click(btnYes);
            Thread.Sleep(1000);
            return this;
        }

        public iALifeInsuranceCalcpage ClickFieldsForSingleNonSmokerMan()
        {

            Highlight(btnMan);
            Click(btnMan);

            Highlight(btnSingle);
            Click(btnSingle);

            Highlight(btnSmoker);
            Click(btnNSmoker);
            Click(btnYes);
            Thread.Sleep(1000);
            return this;
        }

        public iALifeInsuranceCalcpage ClickFieldsForCoupleNonSmokerMan()
        {

            Highlight(btnMan);
            Click(btnMan);

            Highlight(btnCouple);
            Click(btnCouple);

            Highlight(btnNSmoker);
            Click(btnNSmoker);
            Click(btnYes);
            Thread.Sleep(1000);
            return this;
        }

        public iALifeInsuranceCalcpage ClickFieldsForCoupleSmokerMan()
        {

            Highlight(btnMan);
            Click(btnMan);

            Highlight(btnCouple);
            Click(btnCouple);

            Highlight(btnSmoker);
            Click(btnSmoker);
            Click(btnYes);
            Thread.Sleep(1000);
            return this;
        }

        public iALifeInsuranceCalcpage PopulateFields(string birthDate, string Amount)
        {
            Highlight(birthdate);
            EnterText(birthdate, birthDate);
            Highlight(amntTxtBox);
            EnterText(amntTxtBox, Amount);
            return this;
        }

        public iALifeInsuranceCalcpage DoNotClickAnything() 
        {
            Scroll(txtAboutYou);
            return this;
        }
        public iALifeInsuranceCalcpage ValidateErrorMessage() 
        {
            Scroll(txtAboutYou);

            Highlight(errorMsgGender);
            Assert.IsTrue(FindElement(errorMsgGender).Displayed);

            Highlight(errorMsgStatus);
            Assert.IsTrue(FindElement(errorMsgStatus).Displayed);

            Highlight(errorMsgVices);
            Assert.IsTrue(FindElement(errorMsgVices).Displayed);

            Highlight(errorMsgbday);
            Assert.IsTrue(FindElement(errorMsgbday).Displayed);
            
            Scroll(btnYes);

            Highlight(errorMsg);
            Assert.IsTrue(FindElement(errorMsg).Displayed);
            return this;
        }

        public iALifeInsuranceCalcpage CalculateEmpty()
        {
            Highlight(btnCalc);
            Click(btnCalc);
            Thread.Sleep(3000);
            return this;
        }

        public iALifeInsuranceResultpage Calculate()
        {
            Highlight(btnCalc);
            Click(btnCalc);
            Thread.Sleep(3000);
            return new iALifeInsuranceResultpage(driver);
        }

    }
}
