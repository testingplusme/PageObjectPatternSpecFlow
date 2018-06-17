using System.Linq;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
            waitHelper.WaitForClickable(pollPage.CookiePolicy);
            pollPage.CookiePolicy.Click();
        }

        [When(@"I add ""tak"" vote")]
        public void WhenIAddVote()
        {
            seleniumHelper.MoveToElementAndClick(pollPage.ViewResults);
            waitHelper.WaitForClickable(pollPage.VotesCounter);
            scenarioContext.Set<int>(pollPage.AmountOfVotes,"AMOUNT-OF-POLLS");
            seleniumHelper.MoveToElementAndClick(pollPage.ReturnToPoll);
            seleniumHelper.MoveToElementAndClick(pollPage.PollAnswears.First(x => x.Text == "Tak"));
            seleniumHelper.MoveToElementAndClick(pollPage.VoteButton);
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
