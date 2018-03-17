using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace PageObjectPatternPoll.Helpers
{
    [Binding]
    public sealed class Hooks
    {
        private IObjectContainer container;
        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver= new ChromeDriver();
            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = container.Resolve<IWebDriver>();
            driver.Close();
            driver.Dispose();
            container.Dispose();
        }
    }
}
