using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AiSpecflowAutomation.Drivers;
using OpenQA.Selenium;

namespace AiSpecflowAutomation.Config
{
    [Binding]
    public sealed class Hooks
    {
        private readonly DriverHelper _helper;
        private static ExtentReports _extent = default!;
        private static ExtentHtmlReporter _reporter = default!;
        private static ExtentTest _scenario = default!;
        private static ExtentTest _featureName = default!;
        private static readonly string _basePath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net7.0", "");
        public Hooks(DriverHelper helper)
        {
            _helper = helper;
            

        }

        [BeforeTestRun]
        public static void SetUpReport()
        {
            var path =  @$"{_basePath}\Report\";

            _extent = new ExtentReports();
            _reporter = new ExtentHtmlReporter(path)
            {
                Config =
                {
                    DocumentTitle = "Automation Testing Report",
                    ReportName = "Extent Report" + DateTime.Now,
                    Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard
                }
            };
            _extent.AttachReporter(_reporter);
            _extent.AddSystemInfo("Machine", Environment.MachineName);
            _extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
        }

        [BeforeFeature]
        public static void CreateTest(FeatureContext featureContext)
        {
            _featureName = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag(ScenarioContext scenarioContext)
        {
            _scenario = _featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            _helper.driver.Manage().Window.Maximize();
            _helper.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var path = @$"{_basePath}\Report\Screenshots";
            var timeStamp = $"{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Year}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}";
            var finalPath = @$"{path}\Image_{timeStamp}.png";

            // Capture screenshot
            var ts = (ITakesScreenshot)_helper.driver;
            var screenshot = ts.GetScreenshot();
            screenshot.SaveAsFile(finalPath, ScreenshotImageFormat.Png);



            // Generate passed test nodes for each Gherkin keyword for scenario run
            if (scenarioContext.TestError == null)
            {
                switch (stepType.ToLower())
                {
                    case "given":
                        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(finalPath);
                        break;                   
                    case "when":
                        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(finalPath);
                        break;
                    case "then":
                        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(finalPath);
                        break;                        
                    case "and":
                        _scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(finalPath);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(stepType));
                }
            }

            // Generate failed test nodes for each Gherkin keyword for scenario run
            else
            {
                switch (stepType.ToLower())
                {
                    case "given":
                        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message)
                            .AddScreenCaptureFromBase64String(finalPath);
                        break;
                    case "when":
                        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message)
                            .AddScreenCaptureFromBase64String(finalPath);
                        break;
                    case "then":
                        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message)
                            .AddScreenCaptureFromBase64String(finalPath);
                        break;
                    case "and":
                        _scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message)
                            .AddScreenCaptureFromBase64String(finalPath);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(stepType));
                }
            }
            Thread.Sleep(300);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _extent.Flush();

            // Code to rename the index.html report to Automation Testing Report
            var timeStamp = $"{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Year}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}";

            var oldFilePath =  @$"{_basePath}\Report\index.html";
            var newFilePath = @$"{_basePath}\Report\Automation Testing Report_{timeStamp}.html";
            File.Move(oldFilePath, newFilePath);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _helper.driver.Quit();
        }
    }
}