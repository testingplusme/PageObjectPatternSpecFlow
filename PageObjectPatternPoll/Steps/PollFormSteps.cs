using System.Linq;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
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
            waitHelper.WaitForClickable(pollPage.ViewResults);
            pollPage.ViewResults.Click();
            waitHelper.WaitForClickable(pollPage.VotesCounter);
            scenarioContext.Set<int>(pollPage.AmountOfVotes,"AMOUNT-OF-POLLS");
            waitHelper.WaitForClickable(pollPage.ReturnToPoll);
            pollPage.ReturnToPoll.Click();
            waitHelper.WaitForClickable(pollPage.PollAnswears.First(x => x.Text=="Tak"));
            pollPage.PollAnswears.First(x => x.Text == "Tak").Click();
            waitHelper.WaitForClickable(pollPage.VoteButton);
            pollPage.VoteButton.Click();
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
