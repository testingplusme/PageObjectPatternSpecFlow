using System.Linq;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObjectPatternPoll.Helpers;
using PageObjectPatternPoll.Pages;
using TechTalk.SpecFlow;

namespace PageObjectPatternPoll.Steps
{
    [Binding]
    public sealed class PollFormSteps
    {
        private IObjectContainer container;
        public IWebDriver Driver => container.Resolve<IWebDriver>();
        private PollPage pollPage;
        private SeleniumHelper seleniumHelper;
        private WaitHelper waitHelper;
        private ScenarioContext scenarioContext;

        public PollFormSteps(IObjectContainer container, PollPage pollPage,SeleniumHelper seleniumHelper,WaitHelper waitHelper,ScenarioContext scenarioContext)
        {
            this.container = container;
            this.pollPage = pollPage;
            this.seleniumHelper = seleniumHelper;
            this.waitHelper = waitHelper;
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I enter to poll page")]
        public void GivenIEnterToPollPage()
        {
           seleniumHelper.GoToPage(TestSettings.PollFormUrl);   
        }

        [When(@"I check view of poll form")]
        public void WhenICheckViewOfPollForm()
        {
            waitHelper.WaitForClickable(pollPage.PollBox);  
            Assert.True(pollPage.PollBox.Displayed,"pollPage.PollBox.Displayed is false");
            pollPage.CookiePolicy.Click();
        }

        [When(@"I add ""tak"" vote")]
        public void WhenIAddVote()
        {
            var actions = new Actions(Driver);
            waitHelper.WaitForClickable(pollPage.ViewResults);
            actions.MoveToElement(pollPage.ViewResults).Click().Build().Perform();
            waitHelper.WaitForClickable(pollPage.VotesCounter);
            scenarioContext.Set<int>(pollPage.AmountOfVotes,"AMOUNT-OF-POLLS");
            actions.MoveToElement(pollPage.ViewResults).Click().Build().Perform();
            waitHelper.WaitForClickable(pollPage.ReturnToPoll);
            actions.MoveToElement(pollPage.ReturnToPoll).Build().Perform();
            waitHelper.WaitForClickable(pollPage.PollAnswears.First(x => x.Text=="Tak"));
            actions.MoveToElement(pollPage.PollAnswears.First(x => x.Text == "Tak")).Click().Build().Perform();
            waitHelper.WaitForClickable(pollPage.VoteButton);
            actions.MoveToElement(pollPage.VoteButton).Click().Build().Perform();
        }

        [Then(@"Check amount of votes")]
        public void ThenCheckAmountOfVotes()
        {
            waitHelper.WaitForClickable(pollPage.VotesCounter);
            var savedAmountAfterVote = scenarioContext.Get<int>("AMOUNT-OF-POLLS");
            savedAmountAfterVote++;
            Assert.AreEqual(savedAmountAfterVote, pollPage.AmountOfVotes);
        }

    }
}
