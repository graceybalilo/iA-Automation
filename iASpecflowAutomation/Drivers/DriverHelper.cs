using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace iASpecflowAutomation.Drivers
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
