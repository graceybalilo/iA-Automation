using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AiSpecflowAutomation.Drivers
{
    public class DriverHelper
    {
        public IWebDriver driver;

        public DriverHelper()
        {
            driver = new ChromeDriver();
        }
    }
}
