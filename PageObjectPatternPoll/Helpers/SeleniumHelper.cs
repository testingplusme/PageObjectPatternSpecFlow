using BoDi;
using OpenQA.Selenium;

namespace PageObjectPatternPoll.Helpers
{
    public class SeleniumHelper
    {
        private IWebDriver driver => container.Resolve<IWebDriver>();
        private IObjectContainer container;

        public SeleniumHelper(IObjectContainer container)
        {
            this.container = container;
        }

        public void GoToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }
    }
}
