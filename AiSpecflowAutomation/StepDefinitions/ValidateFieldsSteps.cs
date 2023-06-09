using AiSpecflowAutomation.Pages.GetQuote;
using AiSpecflowAutomation.Drivers;

namespace AiSpecflowAutomation.StepDefinitions
{
    [Binding]
    public class ValidateFieldsSteps
    {
        private readonly IaHomepage _homePage;
        private IaLifeInsuranceCalcpage _lifeInsuranceCalcpage = default!;

        public ValidateFieldsSteps(DriverHelper helper) 
        {
            _homePage = new IaHomepage(helper.driver);
        }
        [Given(@"I click the Get a Quote button")]
        public void GivenIClickTheGetAQuoteButton()
        {
            _homePage.ClickGetAQuoteButton();
        }

        [Given(@"I select Life Insurance from the dropdown list")]
        public void GivenISelectLifeInsuranceFromTheDropdownList()
        {
            _homePage.ClickLifeInsurance();
        }

        [Given(@"I click Determine your Needs from the pop-up")]
        public void GivenIClickDetermineYourNeedsFromThePop_Up()
        {
            _lifeInsuranceCalcpage = _homePage.ClickDetermineYourNeeds();
        }

        [Given(@"I did not select anything from the list of questions about myself")]
        public void GivenIDidNotSelectAnythingFromTheListOfQuestionsAboutMyself()
        {
            _lifeInsuranceCalcpage.DoNotClickAnything();
        }

        [Given(@"I did not answer the question about my insurance coverage")]
        public void GivenIDidNotAnswerTheQuestionAboutMyInsuranceCoverage()
        {
            _lifeInsuranceCalcpage.DoNotClickAnything();
        }

        [Given(@"I click the Calculate button")]
        public void GivenIClickTheCalculateButton()
        {
            _lifeInsuranceCalcpage.CalculateEmpty();
        }

        [Then(@"I should see an error message saying Please make a selection")]
        public void ThenIShouldSeeAnErrorMessageSayingPleaseMakeASelection()
        {
            _lifeInsuranceCalcpage.ValidateErrorMessage();
        }

    }
}
