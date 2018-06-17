using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjectPatternPoll.Helpers
{
    public class SeleniumHelper
    {
        private IWebDriver driver => container.Resolve<IWebDriver>();
        private IObjectContainer container;
        private WaitHelper waitHelper;

        public SeleniumHelper(IObjectContainer container, WaitHelper waitHelper)
        {
            this.container = container;
            this.waitHelper = waitHelper;
        }

        public void GoToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public void MoveToElementAndClick(IWebElement element)
        {
            waitHelper.WaitForClickable(element);
            var actions = new Actions(driver);
            actions.MoveToElement(element).Click().Build().Perform();
        }
        
    }
}
