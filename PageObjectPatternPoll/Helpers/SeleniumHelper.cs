using OpenQA.Selenium;

namespace PageObjectPatternPoll.Helpers
{
    public class SeleniumHelper
    {
        private IWebDriver driver;
        public SeleniumHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
