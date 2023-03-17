using AiSpecflowAutomation.Pages.GetQuote;
using AiSpecflowAutomation.Drivers;

namespace AiSpecflowAutomation.StepDefinitions
{
    [Binding]
    public class GetAQuoteSteps
    {
        private readonly IaHomepage _homePage;
        private IaLifeInsuranceCalcpage _lifeInsuranceCalcpage = default!;
        private AiLifeInsuranceResultpage _lifeInsuranceResultpage = default!;

        public GetAQuoteSteps(DriverHelper helper) 
        {
            _homePage = new IaHomepage(helper.driver);
        }

        [Given(@"I am on Industrial Alliance Website")]
        public void GivenIAmOnIndustrialAllianceWebsite()
        {
            _homePage.NavigateToHomePage();
            _homePage.AcceptCookie();
            _homePage.Verify();
        }
 
        [When(@"I click the Get a Quote button")]
        public void WhenIClickTheGetAQuoteButton()
        {
            _homePage.ClickGetAQuoteButton();
        }

        [When(@"I select Life Insurance from the dropdown list")]
        public void WhenISelectLifeInsuranceFromTheDropdownList()
        {
            _homePage.ClickLifeInsurance();
        }

        [When(@"I click Determine your Needs from the pop-up")]
        public void WhenIClickDetermineYourNeedsFromThePop_Up()
        {
           _lifeInsuranceCalcpage =  _homePage.ClickDetermineYourNeeds();
        }

        [When(@"I click the needed fields for calculating my term life insurance")]
        public void WhenIClickTheNeededFieldsForCalculatingMyTermLifeInsurance()
        {
            _lifeInsuranceCalcpage.ClickFieldsforCoupleWoman();
        }

        [When(@"I click the needed fields for single woman and calculate my term life insurance")]
        public void WhenIClickTheNeededFieldsForSingleWomanAndCalculateMyTermLifeInsurance()
        {
            _lifeInsuranceCalcpage.ClickFieldsForSingleNonSmokerWoman();
        }

        [When(@"I click the needed fields for single smoker woman and calculate my term life insurance")]
        public void WhenIClickTheNeededFieldsForSingleSmokerWomanAndCalculateMyTermLifeInsurance()
        {
            _lifeInsuranceCalcpage.ClickFieldsForSingleWoman();
        }

        [When(@"I click the needed fields for single smoker man and calculate my term life insurance")]
        public void WhenIClickTheNeededFieldsForSingleSmokerManAndCalculateMyTermLifeInsurance()
        {
            _lifeInsuranceCalcpage.ClickFieldsForSingleSmokerMan();
        }

        [When(@"I click the needed fields for single non smoker man and calculate my term life insurance")]
        public void WhenIClickTheNeededFieldsForSingleNonSmokerManAndCalculateMyTermLifeInsurance()
        {
            _lifeInsuranceCalcpage.ClickFieldsForSingleNonSmokerMan();
        }

        [When(@"I click the needed fields for couple smoker man and calculate my term life insurance")]
        public void WhenIClickTheNeededFieldsForCoupleSmokerManAndCalculateMyTermLifeInsurance()
        {
            _lifeInsuranceCalcpage.ClickFieldsForCoupleSmokerMan();
        }

        [When(@"I click the needed fields for couple non smoker man and calculate my term life insurance")]
        public void WhenIClickTheNeededFieldsForCoupleNonSmokerManAndCalculateMyTermLifeInsurance()
        {
            _lifeInsuranceCalcpage.ClickFieldsForCoupleNonSmokerMan();
        }


        [When(@"I populate the required fields on the page using ""([^""]*)"", ""([^""]*)""")]
        public void WhenIPopulateTheRequiredFieldsOnThePageUsing(string birthDate, string amount)
        {
            _lifeInsuranceCalcpage.PopulateFields(birthDate, amount);
        }


        [When(@"I click the Calculate button")]
        public void WhenIClickTheCalculateButton()
        {
            _lifeInsuranceResultpage = _lifeInsuranceCalcpage.Calculate();
        }

        [Then(@"I should be able to see the calculation of my insurance based from my inputs")]
        public void ThenIShouldBeAbleToSeeTheCalculationOfMyInsuranceBasedFromMyInputs()
        {
            _lifeInsuranceResultpage.verifyResult();
        }

        [Given(@"I am on iA homepage")]
        public void GivenIAmOnIAHomepage()
        {

            _homePage.NavigateToHomePage();
            _homePage.AcceptCookie();
            _homePage.Verify();
        }

        [When(@"I select the home Insurance from the dropdown")]
        public void WhenISelectTheHomeInsuranceFromTheDropdown()
        {
            _homePage.ClickHomeInsurance();
        }

        [Then(@"the pop-up message for housing insurance will be displayed")]
        public void ThenThePop_UpMessageForHousingInsuranceWillBeDisplayed()
        {
            _homePage.VerifyHomeInsurancePopup();
        }

    }
}
